// <copyright file="UserSeeder.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using Garuda.Domain.Common.Models;

namespace Garuda.Domain.Common.Seeds;

public class UserSeeder
{
    public static User[] Seeds()
    {
        return
        [
            new User
            {
                Id = Guid.Parse("81314787-537b-474f-999a-9152c9703bbb"),
                Email = "system@system.co",
                Username = "systemadmin",
                CreatedBy = "System",
                CreatedDate = new DateTime(2022, 06, 03, 0, 0, 0),
                Fullname = "System",
                Password = "$2a$11$ijs7c9x9yHz1oeZ95CF76u1CGALKC3sVeMpGyfzA0U7gWlpH7tmhO",
            },
            new User
            {
                Id = Guid.Parse("fa3876d9-b8ce-4029-9df6-2e8ee94a3d78"),
                Email = "systemreserve@system.co",
                CreatedBy = "System",
                CreatedDate = new DateTime(2022, 06, 03, 0, 0, 0),
                Username = "systemadminreserve",
                Fullname = "System Admin Reserve",
                Password = "$2a$11$ijs7c9x9yHz1oeZ95CF76u1CGALKC3sVeMpGyfzA0U7gWlpH7tmhO",
            },
            new User
            {
                Id = Guid.Parse("c3e20f8e-92a7-4c19-90a2-7fb66fd1b6b1"),
                Email = "buyer@platform.com",
                CreatedBy = "System",
                CreatedDate = new DateTime(2024, 08, 15, 0, 0, 0),
                Username = "buyer",
                Fullname = "Buyer User",
                Password = "$2a$12$7hXoj0eKxTvhwo9qKYZdQOE1aiHaqHdhDlBjSzAqAjSs1u0ILF.EG",
            },
            new User
            {
                Id = Guid.Parse("f7a74c57-8968-4b3a-91e5-38b2f6aef91c"),
                Email = "seller@platform.com",
                CreatedBy = "System",
                CreatedDate = new DateTime(2024, 08, 15, 0, 0, 0),
                Username = "seller",
                Fullname = "Seller User",
                Password = "$2a$12$lVXtNCUzJaFgAmJ.sJvSheGHJlZuQG96ZZGReyJn9lxg2WEbuAYDW",
            }
        ];
    }
}