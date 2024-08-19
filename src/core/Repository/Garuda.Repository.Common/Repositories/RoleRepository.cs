// <copyright file="RoleRepository.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using Garuda.Domain.Common.Models;
using Garuda.Persistences.Framework;
using Garuda.Repository.Common.Repositories.Contracts;
using Garuda.Utilities.Constants.Errors;
using Microsoft.EntityFrameworkCore;

#pragma warning disable CS8603 // Possible null reference return.

namespace Garuda.Repository.Common.Repositories;

public class RoleRepository : RepositoryBase<Role>, IRoleRepository
{
    public IQueryable<Role> Query()
    {
        return this.dbSet;
    }

    public async Task<Role> Get(Guid id)
    {
        return await this.dbSet.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<Role>> GetAll()
    {
        return await this.dbSet.ToListAsync();
    }

    public async Task<Role> Create(Role model)
    {
        await this.dbSet.AddAsync(model);
        return model;
    }

    public async Task<Role> Update(Guid id, Role model)
    {
        var role = await this.dbSet.FirstOrDefaultAsync(x => x.Id == id);
        if (role == null)
        {
            throw Error.DataNotFound();
        }

        role.Name = model.Name;

        this.dbSet.Update(role);
        return role;
    }

    public async Task<Role> Delete(Guid id)
    {
        var role = await this.dbSet.FirstOrDefaultAsync(x => x.Id == id);
        if (role == null)
        {
            throw Error.DataNotFound();
        }

        this.dbSet.Remove(role);
        return role;
    }

    public async Task<Role> GetAndValidateDuplicate(Guid? id, string name, bool isActive)
    {
        if (id != null)
        {
            var role = await this.dbSet.FirstOrDefaultAsync(x => x.Id != id &&
                                                                 x.Name.Equals(name,
                                                                               StringComparison
                                                                                   .CurrentCultureIgnoreCase) &&
                                                                 (isActive ?
                                                                      x.DeletedDate == null :
                                                                      x.DeletedDate != null));
            if (role != null)
            {
                throw Error.Conflict();
            }
        }
        else
        {
            var role = await this.dbSet.FirstOrDefaultAsync(x => x.Name.Equals(name,
                                                                               StringComparison
                                                                                   .CurrentCultureIgnoreCase) &&
                                                                 (isActive ?
                                                                      x.DeletedDate == null :
                                                                      x.DeletedDate != null));
            if (role != null)
            {
                throw Error.Conflict();
            }
        }

        return new Role { Name = name, DeletedDate = isActive ? DateTime.UtcNow : null };
    }
}