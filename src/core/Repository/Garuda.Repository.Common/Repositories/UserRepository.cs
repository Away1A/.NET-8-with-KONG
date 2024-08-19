// <copyright file="UserRepository.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using Garuda.Domain.Common.Models;
using Garuda.Persistences.Framework;
using Garuda.Repository.Common.Helper;
using Garuda.Repository.Common.Repositories.Contracts;
using Garuda.Utilities.Constants.Errors;
using Microsoft.EntityFrameworkCore;

#pragma warning disable CS8603 // Possible null reference return.

namespace Garuda.Repository.Common.Repositories;

public class UserRepository : RepositoryBase<User>, IUserRepository
{
    public IQueryable<User> Query()
    {
        return this.dbSet;
    }

    public async Task<User> Get(Guid id)
    {
        return await this.dbSet.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<User>> GetAll()
    {
        return await this.dbSet.ToListAsync();
    }

    public async Task<User> Create(User model)
    {
        await ValidateDuplicateByName(model.Username);
        await this.dbSet.AddAsync(model);
        return model;
    }

    public async Task<User> Update(Guid id, User model)
    {
        await ValidateDuplicateByIdAndByName(id, model.Username);
        var user = await GetAndValidateById(id);

        user.Username = model.Username;
        user.Email = model.Email;
        user.Fullname = model.Fullname;
        user.Password = model.Password;
        user.LastLogin = model.LastLogin;
        user.UserRoles = model.UserRoles;

        this.dbSet.Update(user);
        return user;
    }

    public async Task<User> Delete(Guid id)
    {
        var user = await GetAndValidateById(id);

        this.dbSet.Remove(user);
        return user;
    }

    public async Task<User> GetAndValidateById(Guid id)
    {
        var user = await this.dbSet.FirstOrDefaultAsync(x => x.Id == id);
        if (user == null)
        {
            throw Error.DataNotFound();
        }

        return user;
    }

    public async Task ValidateDuplicateByName(string name)
    {
        var user =
            await this.dbSet.FirstOrDefaultAsync(x =>
                                                     x.Username.Equals(name,
                                                                       StringComparison.CurrentCultureIgnoreCase));
        if (user != null)
        {
            throw Error.Conflict();
        }
    }

    public async Task ValidateDuplicateByIdAndByName(Guid id, string name)
    {
        var user = await this.dbSet.FirstOrDefaultAsync(x => x.Id != id &&
                                                             x.Username.Equals(name,
                                                                               StringComparison
                                                                                   .CurrentCultureIgnoreCase));
        if (user != null)
        {
            throw Error.Conflict();
        }
    }

    public async Task<User> GetAndValidateUsernameAndPassword(string username, string password)
    {
        var user = await this.dbSet.FirstOrDefaultAsync(x => x.Username == username);
        if (user == null)
        {
            throw Error.Conflict();
        }

        if (!password.VerifyPassword(user.Password))
        {
            throw Error.InvalidCredential();
        }

        return user;
    }
}