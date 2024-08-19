// <copyright file="RoleSeeder.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using Garuda.Domain.Common.Models;

namespace Garuda.Domain.Common.Seeds;

public class RoleSeeder
{
    public static Role[] Seeds()
    {
        return
        [
            new Role
            {
                Id = Guid.Parse("9ee09365-b140-4bc0-a5a1-79098ddbeed7"),
                Name = "Administrator",
                CreatedBy = "System",
                CreatedDate = new DateTime(2022, 06, 03, 0, 0, 0),
            },
            new Role
            {
                Id = Guid.Parse("91e4aa02-8c2f-4074-9a47-5e33d7ab641c"),
                Name = "Buyer",
                CreatedBy = "System",
                CreatedDate = new DateTime(2023, 06, 02, 0, 0, 0),
            },
            new Role
            {
                Id = Guid.Parse("f5105f3d-579f-42d8-be30-5b78249cba45"),
                Name = "Seller",
                CreatedBy = "System",
                CreatedDate = new DateTime(2023, 06, 03, 0, 0, 0),
            }
        ];
    }
}