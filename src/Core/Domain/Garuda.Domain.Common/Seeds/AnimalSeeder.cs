// <copyright file="AnimalSeeder.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using Garuda.Domain.Common.Models;

namespace Garuda.Domain.Common.Seeds
{
    public class AnimalSeeder
    {
        public static Animal[] Seeds()
        {
            return new[]
            {
                new Animal
                {
                    Id = Guid.NewGuid(),
                    Name = "Lion",
                    Type = "Mammal",
                    Gender = "Male",
                    Age = 5,
                    Price = 1500.00m,
                    Description = "A majestic lion.",
                    Status = "Approved",
                    ApprovedBy = "admin@example.com",
                    ApprovedDate = DateTime.UtcNow,
                    RejectedBy = null,
                    RejectionReason = null,
                    RejectedDate = null,
                    PermittedBy = "admin@example.com",
                    PermittedDate = DateTime.UtcNow,
                },
                new Animal
                {
                    Id = Guid.NewGuid(),
                    Name = "Parrot",
                    Type = "Bird",
                    Gender = "Female",
                    Age = 2,
                    Price = 300.00m,
                    Description = "A colorful parrot.",
                    Status = "Pending",
                    ApprovedBy = null,
                    ApprovedDate = null,
                    RejectedBy = null,
                    RejectionReason = null,
                    RejectedDate = null,
                    PermittedBy = null,
                    PermittedDate = null,
                }
            };
        }
    }
}
