// <copyright file="UserSessionRepository.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using Garuda.Domain.Common.Models;
using Garuda.Persistences.Framework;
using Garuda.Repository.Common.Repositories.Contracts;
using Garuda.Utilities.Constants.Errors;
using Microsoft.EntityFrameworkCore;

#pragma warning disable CS8603 // Possible null reference return.

namespace Garuda.Repository.Common.Repositories;

public class UserSessionRepository : RepositoryBase<UserSession>, IUserSessionRepository
{
    public IQueryable<UserSession> Query()
    {
        return this.dbSet;
    }

    public async Task<UserSession> Get(Guid id)
    {
        return await this.dbSet.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<UserSession>> GetAll()
    {
        return await this.dbSet.ToListAsync();
    }

    public async Task<UserSession> Create(UserSession model)
    {
        await this.dbSet.AddAsync(model);
        return model;
    }

    public async Task<UserSession> Update(Guid id, UserSession model)
    {
        var userSession = await GetAndValidateRefreshToken(model.RefreshToken);

        userSession.Token = model.Token;
        userSession.RefreshToken = model.RefreshToken;
        userSession.DateRevoked = model.DateRevoked;
        userSession.DateExpired = model.DateExpired;
        userSession.UserId = model.UserId;

        this.dbSet.Update(userSession);
        return userSession;
    }

    public async Task<UserSession> Delete(Guid id)
    {
        var userSession = await GetAndValidateId(id);

        userSession.DateRevoked = DateTime.UtcNow;

        this.dbSet.Update(userSession);
        return userSession;
    }

    public async Task<UserSession> GetAndValidateId(Guid id)
    {
        var userSession = await this.dbSet.FirstOrDefaultAsync(x => x.Id == id);
        if (userSession == null)
        {
            throw Error.DataNotFound();
        }

        return userSession;
    }

    public async Task<UserSession> GetAndValidateByUserId(Guid id)
    {
        var userSession = await this.dbSet.FirstOrDefaultAsync(x => x.UserId == id && x.DateRevoked != null);
        if (userSession == null)
        {
            throw Error.DataNotFound();
        }

        return userSession;
    }

    public async Task<UserSession> GetAndValidateRefreshToken(string refreshToken)
    {
        var userSession =
            await this.dbSet.FirstOrDefaultAsync(x => x.RefreshToken == refreshToken && x.DateRevoked != null);
        if (userSession == null)
        {
            throw Error.Unauthorized("Your session is invalid, please login again.");
        }

        return userSession;
    }

    public async Task<UserSession> RevokeToken(string token)
    {
        var userSession = await this.dbSet.FirstOrDefaultAsync(x => x.RefreshToken == token && x.DateRevoked != null);
        if (userSession == null)
        {
            throw Error.Unauthorized("Your session is invalid, please login again.");
        }

        userSession.DateRevoked = DateTime.UtcNow;

        this.dbSet.Update(userSession);
        return userSession;
    }
}