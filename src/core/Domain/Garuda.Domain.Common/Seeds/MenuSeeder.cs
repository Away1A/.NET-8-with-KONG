// <copyright file="MenuSeeder.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using Garuda.Domain.Common.Models;

namespace Garuda.Domain.Common.Seeds;

public class MenuSeeder
{
    public static Menu[] Seeds()
    {
        return
        [
            new Menu
            {
                Id = Guid.Parse("8f735cdf-bd01-4ae3-89c6-b122bdd59b8b"),
                ParentId = Guid.Empty,
                IconClass = "icon-home",
                Code = "dash",
                Name = "Dashboard",
                Level = 0,
                Slug = "/Dashboard",
                Order = 0,
                CreatedBy = "System",
                CreatedDate = new DateTime(2022, 06, 03, 0, 0, 0),
            },
            new Menu
            {
                Id = Guid.Parse("77118193-d70c-4e36-97a0-683b9e825569"),
                ParentId = Guid.Empty,
                IconClass = "icon-notes",
                Code = "act",
                Name = "My Activity",
                Level = 0,
                Slug = "/IndexMyActivity",
                Order = 2,
                CreatedBy = "System",
                CreatedDate = new DateTime(2022, 06, 03, 0, 0, 0),
            },
            new Menu
            {
                Id = Guid.Parse("7f2302be-efd5-43f1-b6c9-8e8886c8460c"),
                ParentId = Guid.Empty,
                IconClass = "icon-file",
                Code = "doc",
                Name = "My Document",
                Level = 0,
                Slug = string.Empty,
                Order = 3,
                CreatedBy = "System",
                CreatedDate = new DateTime(2022, 06, 03, 0, 0, 0),
            },
            new Menu
            {
                Id = Guid.Parse("f0663ca2-ffb8-42c2-b022-38479c7c84af"),
                ParentId = Guid.Empty,
                IconClass = "icon-cog-outline",
                Code = "set",
                Name = "Settings",
                Level = 0,
                Slug = string.Empty,
                Order = 5,
                CreatedBy = "System",
                CreatedDate = new DateTime(2022, 06, 03, 0, 0, 0),
            },
            new Menu
            {
                Id = Guid.Parse("5026c85e-04f4-4d65-9fd2-bff26ad90013"),
                ParentId = Guid.Parse("f0663ca2-ffb8-42c2-b022-38479c7c84af"),
                IconClass = "icon-user",
                Code = "user",
                Name = "User Management",
                Level = 1,
                Slug = "/IndexUser",
                Order = 0,
                CreatedBy = "System",
                CreatedDate = new DateTime(2022, 06, 03, 0, 0, 0),
            },
            new Menu
            {
                Id = Guid.Parse("F45E2F20-E6C3-4D82-B0D9-E91469103672"),
                ParentId = Guid.Parse("F0663CA2-FFB8-42C2-B022-38479C7C84AF"),
                IconClass = string.Empty,
                Code = "sec",
                Name = "Manage Security Group",
                Level = 1,
                Slug = "/IndexSecurity",
                Order = 1,
                CreatedBy = "System",
                CreatedDate = new DateTime(2022, 06, 03, 0, 0, 0),
            }
        ];
    }
}