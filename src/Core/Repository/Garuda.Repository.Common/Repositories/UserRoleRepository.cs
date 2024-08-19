// <copyright file="UserRoleRepository.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using Garuda.Domain.Common.Models;
using Garuda.Persistences.Framework;
using Garuda.Repository.Common.Repositories.Contracts;
using Garuda.Utilities.Constants.Errors;
using Microsoft.EntityFrameworkCore;

#pragma warning disable CS8603 // Possible null reference return.

namespace Garuda.Repository.Common.Repositories;

public class UserRoleRepository : RepositoryBase<UserRole>, IUserRoleRepository
{
    public IQueryable<UserRole> Query()
    {
        return this.dbSet;
    }

    public async Task<UserRole> Get(Guid id)
    {
        return await this.dbSet.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<UserRole>> GetAll()
    {
        return await this.dbSet.ToListAsync();
    }

    public async Task<UserRole> Create(UserRole model)
    {
        await this.dbSet.AddAsync(model);
        return model;
    }

    public async Task<UserRole> Update(Guid id, UserRole model)
    {
        var userRole = await GetAndValidateById(id);

        userRole.RoleId = model.RoleId;
        userRole.UserId = model.UserId;

        return userRole;
    }

    public async Task<UserRole> Delete(Guid id)
    {
        var userRole = await this.dbSet.FirstOrDefaultAsync(x => x.Id == id);
        if (userRole == null)
        {
            throw Error.DataNotFound();
        }

        this.dbSet.Remove(userRole);

        return userRole;
    }

    public async Task DeleteByUserIdAndRoleId(Guid userId, Guid roleId)
    {
        var userRole = await this.dbSet.FirstOrDefaultAsync(x => x.UserId == userId && x.RoleId == roleId);
        if (userRole == null)
        {
            throw Error.DataNotFound();
        }

        this.dbSet.Remove(userRole);
    }

    public async Task<UserRole> GetAndValidateById(Guid id)
    {
        var userRole = await this.dbSet.FirstOrDefaultAsync(x => x.Id == id);
        if (userRole == null)
        {
            throw Error.DataNotFound();
        }

        return userRole;
    }
}