// <copyright file="UserRoleSeeder.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using Garuda.Domain.Common.Models;

namespace Garuda.Domain.Common.Seeds;

public class UserRoleSeeder
{
    public static UserRole[] Seeds()
    {
        return
        [
            new UserRole
            {
                Id = Guid.Parse("ec211d37-2400-4877-8696-62ac17faeecb"),
                UserId = Guid.Parse("81314787-537b-474f-999a-9152c9703bbb"),
                RoleId = Guid.Parse("9ee09365-b140-4bc0-a5a1-79098ddbeed7"),
                CreatedBy = "System",
                CreatedDate = new DateTime(2022, 06, 03, 0, 0, 0),
            },
            new UserRole
            {
                Id = Guid.Parse("12ae4f23-8457-4e71-898a-4d36aa2611b2"),
                UserId = Guid.Parse("c3e20f8e-92a7-4c19-90a2-7fb66fd1b6b1"),
                RoleId = Guid.Parse("91e4aa02-8c2f-4074-9a47-5e33d7ab641c"),
                CreatedBy = "System",
                CreatedDate = new DateTime(2023, 06, 02, 0, 0, 0),
            },
            new UserRole
            {
                Id = Guid.Parse("d8ffb78d-185c-4d2a-9ad3-52577dcd9392"),
                UserId = Guid.Parse("f7a74c57-8968-4b3a-91e5-38b2f6aef91c"),
                RoleId = Guid.Parse("f5105f3d-579f-42d8-be30-5b78249cba45"),
                CreatedBy = "System",
                CreatedDate = new DateTime(2023, 06, 03, 0, 0, 0),
            }
        ];
    }
}