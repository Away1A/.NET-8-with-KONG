// <copyright file="RoleMenuPermissionService.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using Garuda.Application.Common.Dto.Request;
using Garuda.Application.Common.Dto.Response;
using Garuda.Application.Common.Services.V1.Contracts;
using Garuda.Domain.Common.Models;
using Garuda.Persistences.Abstract.Contracts;
using Garuda.Repository.Common.Repositories.Contracts;
using Garuda.Utilities.Dtos.Response;
using Mapster;
using MapsterMapper;
using Microsoft.Extensions.Logging;
using Sieve.Models;
using Sieve.Services;

namespace Garuda.Application.Common.Services.V1;

public class RoleMenuPermissionService : IRoleMenuPermissionService
{
    private readonly IMapper _mapper;
    private readonly IStorage _storage;
    private readonly ILogger _logger;
    private readonly ISieveProcessor _sieveProcessor;

    /// <summary>
    /// Initializes a new instance of the <see cref="RoleMenuPermissionService"/> class.
    /// </summary>
    /// <param name="mapper"></param>
    /// <param name="sieveProcessor"></param>
    /// <param name="logger"></param>
    /// <param name="storage"></param>
    public RoleMenuPermissionService(IMapper mapper,
                                     ISieveProcessor sieveProcessor,
                                     ILogger<RoleMenuPermissionService> logger,
                                     IStorage storage)
    {
        _mapper = mapper;
        _sieveProcessor = sieveProcessor;
        _storage = storage;
        _logger = logger;
    }

    public async Task<PaginatedList<ManageSecurityListResponse>> GetList(SieveModel sieveModel)
    {
        var query = _storage.GetRepository<IRoleMenuPermissionRepository>()
                            .Query()
                            .ProjectToType<ManageSecurityListResponse>();

        return await PaginatedList<ManageSecurityListResponse>.CreateAsync(_sieveProcessor.Apply(sieveModel, query),
                                                                           sieveModel.Page ?? 1,
                                                                           sieveModel.PageSize ?? 10);
    }

    public async Task<ManageSecurityDetailsResponse> GetByRoleId(Guid id)
    {
        var role = await _storage.GetRepository<IRoleRepository>().Get(id);
        var manageSecurity = await _storage.GetRepository<IRoleMenuPermissionRepository>().GetListByRoleId(id);
        var listMenu = _mapper.From(await _storage.GetRepository<IMenuRepository>().GetParent())
                              .AdaptToType<List<MenuResponse>>();

        foreach (var menu in listMenu)
        {
            menu.Child = _mapper
                         .From(await _storage.GetRepository<IMenuRepository>().GetChildByParentId(menu.Id))
                         .AdaptToType<List<MenuResponse>>();
        }

        var result = new ManageSecurityDetailsResponse()
        {
            Name = role.Name,
            Id = role.Id,
            IsActive = role.DeletedDate == null,
            Permissions = _mapper.From(manageSecurity).AdaptToType<List<MenuPermissionsResponse>>(),
        };

        return result;
    }

    public async Task Create(PostManageSecurityRequest model)
    {
        var role = await _storage.GetRepository<IRoleRepository>()
                                 .GetAndValidateDuplicate(null, model.Name, model.IsActive);
        await _storage.GetRepository<IRoleRepository>().Create(role);
        await HandleMenuPermission(role.Id, model.MenuPermissions);
        await _storage.SaveAsync();
    }

    public async Task Update(Guid id, PutManageSecurityRequest model)
    {
        var role = await _storage.GetRepository<IRoleRepository>()
                                 .GetAndValidateDuplicate(id, model.Name, model.IsActive);
        await _storage.GetRepository<IRoleRepository>().Update(id, role);
        await HandleMenuPermission(role.Id, model.MenuPermissions);
        await _storage.SaveAsync();
    }

    public async Task Delete(Guid id)
    {
        await _storage.GetRepository<IRoleRepository>().Delete(id);
        await _storage.SaveAsync();
    }

    /// <summary>
    /// Handles the menu permissions for a role.
    /// </summary>
    /// <param name="roleId">The ID of the role.</param>
    /// <param name="menuPermissions">The list of menu permissions.</param>
    private async Task HandleMenuPermission(Guid roleId, List<MenuPermissionRequest> menuPermissions)
    {
        foreach (var menuPermission in menuPermissions)
        {
            var menu = await _storage.GetRepository<IMenuRepository>().Get(menuPermission.MenuId);
            var roleMenuPermission = TransformRoleMenuPermission(menu.Id, roleId, menuPermission);
            await _storage.GetRepository<IRoleMenuPermissionRepository>().Create(roleMenuPermission);
        }
    }

    /// <summary>
    /// Transforms the given menu permission request into a RoleMenuPermission object.
    /// </summary>
    /// <param name="menuId">The ID of the menu.</param>
    /// <param name="roleId">The ID of the role.</param>
    /// <param name="menuPermission">The menu permission request.</param>
    /// <returns>A RoleMenuPermission object with the transformed properties.</returns>
    private RoleMenuPermission TransformRoleMenuPermission(Guid menuId,
                                                           Guid roleId,
                                                           MenuPermissionRequest menuPermission)
    {
        return new RoleMenuPermission
        {
            MenuId = menuId,
            RoleId = roleId,
            CanView = menuPermission.Read,
            CanUpdate = menuPermission.Update,
            CanCreate = menuPermission.Create,
            CanDelete = menuPermission.Delete,
        };
    }
}