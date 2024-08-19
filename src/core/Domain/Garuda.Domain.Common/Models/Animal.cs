// <copyright file="Animal.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using Garuda.Domain.Common.Seeds;
using Garuda.Persistences.Abstract.Contracts;
using Garuda.Persistences.Framework;
using Microsoft.EntityFrameworkCore;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace Garuda.Domain.Common.Models
{
    public class Animal : BaseModel, IEntity, IEntityRegister
    {
        /// <summary>
        ///     Gets or sets the name of the animal (mandatory).
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the type of the animal (e.g., Mammal, Bird) (mandatory).
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        ///     Gets or sets the gender of the animal (mandatory).
        /// </summary>
        public string Gender { get; set; }

        /// <summary>
        ///     Gets or sets the age of the animal (mandatory).
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        ///     Gets or sets the price of the animal (mandatory).
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        ///     Gets or sets the description of the animal (optional).
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        ///     Gets or sets the status of the animal (e.g., "Pending", "Approved", "Rejected", "Permitted") (mandatory).
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        ///     Gets or sets the user who approved the animal (optional, only relevant for approved animals).
        /// </summary>
        public string? ApprovedBy { get; set; }

        /// <summary>
        ///     Gets or sets the date when the animal was approved (optional, only relevant for approved animals).
        /// </summary>
        public DateTime? ApprovedDate { get; set; }

        /// <summary>
        ///     Gets or sets the user who rejected the animal (optional, only relevant for rejected animals).
        /// </summary>
        public string? RejectedBy { get; set; }

        /// <summary>
        ///     Gets or sets the reason for rejection (optional, only relevant for rejected animals).
        /// </summary>
        public string? RejectionReason { get; set; }

        /// <summary>
        ///     Gets or sets the date when the animal was rejected (optional, only relevant for rejected animals).
        /// </summary>
        public DateTime? RejectedDate { get; set; }

        /// <summary>
        ///     Gets or sets the user who permitted the animal (optional, only relevant for permitted animals).
        /// </summary>
        public string? PermittedBy { get; set; }

        /// <summary>
        ///     Gets or sets the date when the animal was permitted (optional, only relevant for permitted animals).
        /// </summary>
        public DateTime? PermittedDate { get; set; }

        /// <summary>
        ///     Model builder to create its own model to declare fields and relations.
        /// </summary>
        /// <param name="modelbuilder"></param>
        public void RegisterEntities(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Animal>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).HasColumnName("id").ValueGeneratedOnAdd();

                entity.Property(e => e.Name).HasColumnName("name").HasMaxLength(50).IsRequired();

                entity.Property(e => e.Type).HasColumnName("type").HasMaxLength(50).IsRequired();

                entity.Property(e => e.Gender).HasColumnName("gender").HasMaxLength(10).IsRequired();

                entity.Property(e => e.Age).HasColumnName("age").IsRequired();

                entity.Property(e => e.Price).HasColumnName("price").HasColumnType("decimal(18,2)").IsRequired();

                entity.Property(e => e.Description).HasColumnName("description").HasMaxLength(500);

                entity.Property(e => e.Status).HasColumnName("status").HasMaxLength(20).IsRequired();

                entity.Property(e => e.ApprovedBy).HasColumnName("approved_by").HasMaxLength(50);

                entity.Property(e => e.ApprovedDate).HasColumnName("approved_date");

                entity.Property(e => e.RejectedBy).HasColumnName("rejected_by").HasMaxLength(50);

                entity.Property(e => e.RejectionReason).HasColumnName("rejection_reason").HasMaxLength(500);

                entity.Property(e => e.RejectedDate).HasColumnName("rejected_date");

                entity.Property(e => e.PermittedBy).HasColumnName("permitted_by").HasMaxLength(50);

                entity.Property(e => e.PermittedDate).HasColumnName("permitted_date");

                entity.Property(x => x.CreatedDate).HasColumnName("created_date");

                entity.Property(x => x.CreatedBy).HasColumnName("created_by");

                entity.Property(x => x.UpdatedDate).HasColumnName("updated_date");

                entity.Property(x => x.UpdatedBy).HasColumnName("updated_by");

                entity.Property(x => x.DeletedDate).HasColumnName("deleted_date");

                entity.Property(x => x.DeletedBy).HasColumnName("deleted_by");

                entity.ToTable("animals");

                entity.HasData(AnimalSeeder.Seeds());
            });
        }
    }
}
