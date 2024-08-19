// <copyright file="RoleMenuPermissionRepository.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using Garuda.Domain.Common.Models;
using Garuda.Persistences.Framework;
using Garuda.Repository.Common.Repositories.Contracts;
using Garuda.Utilities.Constants.Errors;
using Microsoft.EntityFrameworkCore;

#pragma warning disable CS8603 // Possible null reference return.

namespace Garuda.Repository.Common.Repositories;

public class RoleMenuPermissionRepository : RepositoryBase<RoleMenuPermission>, IRoleMenuPermissionRepository
{
    public IQueryable<RoleMenuPermission> Query()
    {
        return this.dbSet;
    }

    public async Task<RoleMenuPermission> Get(Guid id)
    {
        return await this.dbSet.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<RoleMenuPermission> Create(RoleMenuPermission model)
    {
        await this.dbSet.AddAsync(model);
        return model;
    }

    public async Task<RoleMenuPermission> Update(Guid id, RoleMenuPermission model)
    {
        var roleMenuPermission =
            await this.dbSet.FirstOrDefaultAsync(x => x.Id == id &&
                                                      x.MenuId == model.MenuId &&
                                                      x.RoleId == model.RoleId);
        if (roleMenuPermission == null)
        {
            throw Error.DataNotFound();
        }

        roleMenuPermission.CanView = model.CanView;
        roleMenuPermission.CanUpdate = model.CanUpdate;
        roleMenuPermission.CanCreate = model.CanCreate;
        roleMenuPermission.CanDelete = model.CanDelete;

        return roleMenuPermission;
    }

    public async Task<RoleMenuPermission> Delete(Guid id)
    {
        var roleMenuPermission = await this.dbSet.FirstOrDefaultAsync(x => x.Id == id);
        if (roleMenuPermission == null)
        {
            throw Error.DataNotFound();
        }

        this.dbSet.Remove(roleMenuPermission);
        return roleMenuPermission;
    }

    public async Task<List<RoleMenuPermission>> GetListByRoles(Guid menuItemId, List<Guid> roles)
    {
        return await this.dbSet.Where(x => roles.Contains(x.RoleId)).ToListAsync();
    }

    public async Task<List<RoleMenuPermission>> GetListByRoleId(Guid roleId)
    {
        return await this.dbSet.Where(x => x.RoleId == roleId &&
                                           x.DeletedDate == null &&
                                           x.Menu.DeletedDate == null &&
                                           x.Role.DeletedDate == null)
                               .ToListAsync();
    }
}