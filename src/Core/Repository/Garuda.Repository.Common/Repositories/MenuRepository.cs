// <copyright file="MenuRepository.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using Garuda.Domain.Common.Models;
using Garuda.Persistences.Framework;
using Garuda.Repository.Common.Repositories.Contracts;
using Garuda.Utilities.Constants.Errors;
using Microsoft.EntityFrameworkCore;

#pragma warning disable CS8603 // Possible null reference return.

namespace Garuda.Repository.Common.Repositories;

public class MenuRepository : RepositoryBase<Menu>, IMenuRepository
{
    public IQueryable<Menu> Query()
    {
        return this.dbSet;
    }

    public async Task<Menu> Get(Guid id)
    {
        return await this.dbSet.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<Menu>> GetParent()
    {
        return await this.dbSet.Where(x => x.ParentId == null && x.DeletedDate == null)
                         .OrderBy(x => x.Order)
                         .ToListAsync();
    }

    public async Task<List<Menu>> GetByUserSession(Guid userId)
    {
        return await this.dbSet
                         .Where(x => x.RoleMenuPermissions.Any(y => y.Role.UserRoles.Any(z => z.UserId == userId)) &&
                                     x.DeletedDate == null)
                         .ToListAsync();
    }

    public async Task<List<Menu>> GetAll()
    {
        return await this.dbSet.Where(x => x.DeletedDate == null).ToListAsync();
    }

    public async Task<Menu> Create(Menu model)
    {
        await this.dbSet.AddAsync(model);
        return model;
    }

    public async Task<Menu> Update(Guid id, Menu model)
    {
        var menu = await GetAndValidateMenu(id);

        menu.ParentId = model.ParentId;
        menu.Code = model.Code;
        menu.IconClass = model.IconClass;
        menu.Name = model.Name;
        menu.Slug = model.Slug;
        menu.Level = model.Level;
        menu.Order = model.Order;

        this.dbSet.Update(menu);
        return menu;
    }

    public async Task<Menu> Delete(Guid id)
    {
        var menu = await GetAndValidateMenu(id);

        this.dbSet.Remove(menu);

        return menu;
    }

    public async Task<List<Menu>> GetChildByParentId(Guid parentId)
    {
        return await this.dbSet.Where(x => x.DeletedDate == null && x.ParentId == parentId)
                         .OrderBy(x => x.Order)
                         .ToListAsync();
    }

    private async Task<Menu> GetAndValidateMenu(Guid id)
    {
        var menu = await this.dbSet.FirstOrDefaultAsync(x => x.Id == id && x.DeletedDate == null);
        if (menu == null)
        {
            throw Error.DataNotFound();
        }

        return menu;
    }
}