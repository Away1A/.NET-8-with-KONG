// <copyright file="MenuService.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using Garuda.Application.Common.Dto;
using Garuda.Application.Common.Dto.Request;
using Garuda.Application.Common.Dto.Response;
using Garuda.Application.Common.Services.V1.Contracts;
using Garuda.Domain.Common.Models;
using Garuda.Persistences.Abstract.Contracts;
using Garuda.Repository.Common.Repositories.Contracts;
using Garuda.Utilities.Configurations;
using Garuda.Utilities.Dtos.Response;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Sieve.Models;
using Sieve.Services;

#pragma warning disable CS8603 // Possible null reference return.

namespace Garuda.Application.Common.Services.V1;

public class MenuService : IMenuService
{
    private readonly ISieveProcessor _sieveProcessor;
    private readonly ILogger _logger;
    private readonly IMapper _mapper;
    private readonly IStorage _storage;

    /// <summary>
    ///     Initializes a new instance of the <see cref="MenuService" /> class.
    /// </summary>
    /// <param name="storage"></param>
    /// <param name="logger"></param>
    /// <param name="mapper"></param>
    /// <param name="sieveProcessor"></param>
    public MenuService(IStorage storage, ILogger<MenuService> logger, IMapper mapper, ISieveProcessor sieveProcessor)
    {
        _storage = storage;
        _logger = logger;
        _mapper = mapper;
        _sieveProcessor = sieveProcessor;
    }

    public async Task<MenuResponse> Get(Guid id)
    {
        return await _storage.GetRepository<IMenuRepository>()
                             .Query()
                             .ProjectToType<MenuResponse>()
                             .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<MenuResponse>> GetList()
    {
        var menus = await _storage.GetRepository<IMenuRepository>().Query().ProjectToType<MenuResponse>().ToListAsync();
        foreach (var menu in menus)
        {
            var permissions = new MenuPermissionsResponse
            {
                CanView = false, CanCreate = false, CanUpdate = false, CanDelete = false,
            };

            menu.Permissions = permissions;
        }

        return menus;
    }

    public async Task<PaginatedList<MenuResponse>> GetListByFilter(SieveModel sieveModel)
    {
        var query = _storage.GetRepository<IMenuRepository>().Query().ProjectToType<MenuResponse>();

        return await PaginatedList<MenuResponse>.CreateAsync(_sieveProcessor.Apply(sieveModel,
                                                              query,
                                                              applyPagination: false),
                                                             sieveModel.Page ?? 1,
                                                             sieveModel.PageSize ?? 10);
    }

    public async Task<List<MenuResponse>> GetMenuBySession(SessionDto session)
    {
        var menus = new List<MenuResponse>();
        var user = await _storage.GetRepository<IUserRepository>().Get(session.UserId);
        var role = user.UserRoles.Select(x => x.Role.Id).ToList();
        var parents = await _storage.GetRepository<IMenuRepository>().GetByUserSession(session.UserId);
        foreach (var parent in parents)
        {
            var item = await Map(parent, role);
            menus.Add(item);
        }

        PermissionDictionary.AddToDictionary(user.Id, menus.Select(x => x.Link).ToList());

        return menus;
    }

    public async Task Create(MenuRequest model)
    {
        await _storage.GetRepository<IMenuRepository>().Create(_mapper.From(model).AdaptToType<Menu>());
        await _storage.SaveAsync();
    }

    public async Task Update(Guid id, MenuRequest model)
    {
        await _storage.GetRepository<IMenuRepository>().Update(id, _mapper.From(model).AdaptToType<Menu>());
        await _storage.SaveAsync();
    }

    public async Task Delete(Guid id)
    {
        await _storage.GetRepository<IMenuRepository>().Delete(id);
        await _storage.SaveAsync();
    }

    /// <summary>
    /// Maps a Menu object to a MenuResponses object.
    /// </summary>
    /// <param name="menuItem">The Menu object to map.</param>
    /// <param name="roles">The list of role permissions.</param>
    /// <returns>A MenuResponses object.</returns>
    private async Task<MenuResponse> Map(Menu menuItem, List<Guid> roles)
    {
        var groupMenus = _mapper.From(await _storage.GetRepository<IRoleMenuPermissionRepository>()
                                                    .GetListByRoles(menuItem.Id, roles))
                                .AdaptToType<MenuPermissionsResponse>();

        var item = new MenuResponse
        {
            Name = menuItem.Name, Link = menuItem.Slug, Icon = menuItem.IconClass, Permissions = groupMenus
        };

        await AddChildItemsToMenuRole(item, menuItem.Id, roles);

        return item;
    }

    /// <summary>
    /// Adds child menu items to the given menu role.
    /// </summary>
    /// <param name="item">The menu response item in which child menu items will be added.</param>
    /// <param name="parentId">The ID of the parent menu item.</param>
    /// <param name="role">The list of role names.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    private async Task AddChildItemsToMenuRole(MenuResponse item, Guid parentId, List<Guid> role)
    {
        var childItems = await _storage.GetRepository<IMenuRepository>().GetChildByParentId(parentId);
        foreach (var childItem in childItems)
        {
            var childMenu = await Map(childItem, role);
            if (childMenu.Permissions != null)
            {
                item.Child.Add(childMenu);
            }
        }
    }
}