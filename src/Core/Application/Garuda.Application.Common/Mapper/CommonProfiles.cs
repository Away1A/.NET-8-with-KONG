// <copyright file="CommonProfiles.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System.Text.RegularExpressions;
using Garuda.Application.Common.Dto.Response;
using Garuda.Domain.Common.Models;
using Mapster;

namespace Garuda.Application.Common.Mapper;

/// <summary>
///     Mapper.
/// </summary>
public class CommonProfiles : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<User, UserResponse>()
              .Map(dst => dst.UserRoles,
                   src => src.UserRoles.Select(x => new RoleResponse { Id = x.RoleId, Name = x.Role.Name, }));

        config.NewConfig<Group, RoleResponse>().Map(dst => dst.Name, src => src.Name);

        config.NewConfig<Menu, MenuResponse>()
              .Map(dst => dst.Link, src => src.Slug)
              .Map(dst => dst.Name, src => src.Name);

        config.NewConfig<RoleMenuPermission, MenuPermissionsResponse>().Map(dst => dst.MenuLabel, src => src.Menu.Name);

        config.NewConfig<RoleMenuPermission, ManageSecurityListResponse>()
              .Map(dst => dst.Id, src => src.RoleId)
              .Map(dst => dst.Name, src => src.Role.Name)
              .Map(dst => dst.CreatedOn, src => src.CreatedDate!.Value.ToString("MM/d/yyyy"))
              .Map(dst => dst.IsActive, src => src.Role.DeletedDate == null);
    }
}