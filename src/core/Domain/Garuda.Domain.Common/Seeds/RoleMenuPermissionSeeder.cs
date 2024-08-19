// <copyright file="RoleMenuPermissionSeeder.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using Garuda.Domain.Common.Models;

namespace Garuda.Domain.Common.Seeds;

public class RoleMenuPermissionSeeder
{
    public static RoleMenuPermission[] Seeds()
    {
        return
        [
            new RoleMenuPermission
            {
                // Dashboard
                Id = Guid.Parse("64f03301-c574-46c2-b1e6-2922eaaa826a"),
                MenuId = Guid.Parse("8f735cdf-bd01-4ae3-89c6-b122bdd59b8b"),
                RoleId = Guid.Parse("9ee09365-b140-4bc0-a5a1-79098ddbeed7"),
                CanCreate = false,
                CanDelete = false,
                CanUpdate = false,
                CanView = true,
                CreatedBy = "System",
                CreatedDate = new DateTime(2022, 06, 03, 0, 0, 0),
            },
            new RoleMenuPermission
            {
                // Settings
                Id = Guid.Parse("07e87c49-180f-4f00-99e2-7322c0638a2d"),
                MenuId = Guid.Parse("f0663ca2-ffb8-42c2-b022-38479c7c84af"),
                RoleId = Guid.Parse("9ee09365-b140-4bc0-a5a1-79098ddbeed7"),
                CanCreate = false,
                CanDelete = false,
                CanUpdate = false,
                CanView = true,
                CreatedBy = "System",
                CreatedDate = new DateTime(2022, 06, 03, 0, 0, 0),
            },
            new RoleMenuPermission
            {
                // User Management
                Id = Guid.Parse("702e4653-2abc-41f1-86f5-c1543ab7d585"),
                MenuId = Guid.Parse("5026c85e-04f4-4d65-9fd2-bff26ad90013"),
                RoleId = Guid.Parse("9ee09365-b140-4bc0-a5a1-79098ddbeed7"),
                CanCreate = true,
                CanDelete = true,
                CanUpdate = true,
                CanView = true,
                CreatedBy = "System",
                CreatedDate = new DateTime(2022, 06, 03, 0, 0, 0),
            },
            new RoleMenuPermission
            {
                // User Management
                Id = Guid.Parse("0281EC0D-8FC8-411D-80AB-644A94CF02DA"),
                MenuId = Guid.Parse("77118193-D70C-4E36-97A0-683B9E825569"),
                RoleId = Guid.Parse("9ee09365-b140-4bc0-a5a1-79098ddbeed7"),
                CanCreate = true,
                CanDelete = true,
                CanUpdate = true,
                CanView = true,
                CreatedBy = "System",
                CreatedDate = new DateTime(2022, 06, 03, 0, 0, 0),
            },
            new RoleMenuPermission
            {
                // Manage Security
                Id = Guid.Parse("437EC283-D081-46F4-9F36-A1FFE8753566"),
                MenuId = Guid.Parse("F45E2F20-E6C3-4D82-B0D9-E91469103672"),
                RoleId = Guid.Parse("9ee09365-b140-4bc0-a5a1-79098ddbeed7"),
                CanCreate = false,
                CanDelete = false,
                CanUpdate = false,
                CanView = true,
                CreatedBy = "System",
                CreatedDate = new DateTime(2022, 06, 03, 0, 0, 0),
            }
        ];
    }
}