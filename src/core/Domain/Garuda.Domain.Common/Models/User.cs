// <copyright file="User.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using Garuda.Domain.Common.Seeds;
using Garuda.Persistences.Abstract.Contracts;
using Garuda.Persistences.Framework;
using Microsoft.EntityFrameworkCore;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace Garuda.Domain.Common.Models;

public class User : BaseModel, IEntity, IEntityRegister
{
    /// <summary>
    ///     Gets or sets a value indicating whether gets or sets for Email
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether gets or sets for Fullname
    /// </summary>
    public string Fullname { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether gets or sets for Username
    /// </summary>
    public string Username { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether gets or sets for Password
    /// </summary>
    public string Password { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether gets or sets for LastLogin
    /// </summary>
    public DateTime? LastLogin { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether gets or sets for UserGroups
    /// </summary>
    public IList<UserRole> UserRoles { get; set; } = new List<UserRole>();

    /// <summary>
    ///     Model builder to create it own model to declare field and relation.
    /// </summary>
    /// <param name="modelbuilder"></param>
    public void RegisterEntities(ModelBuilder modelbuilder)
    {
        modelbuilder.Entity<User>(entity =>
                                  {
                                      entity.HasKey(e => e.Id);

                                      entity.Property(e => e.Id).HasColumnName("id").ValueGeneratedOnAdd();

                                      entity.Property(e => e.Email).HasColumnName("email").HasMaxLength(50);

                                      entity.Property(e => e.Fullname).HasColumnName("fullname").HasMaxLength(50);

                                      entity.Property(e => e.Username).HasColumnName("username").HasMaxLength(30);

                                      entity.Property(e => e.LastLogin).HasColumnName("last_login");

                                      entity.Property(x => x.CreatedDate).HasColumnName("created_date");

                                      entity.Property(x => x.CreatedBy).HasColumnName("created_by");

                                      entity.Property(x => x.UpdatedDate).HasColumnName("updated_date");

                                      entity.Property(x => x.UpdatedBy).HasColumnName("updated_by");

                                      entity.Property(x => x.DeletedDate).HasColumnName("deleted_date");

                                      entity.Property(x => x.DeletedBy).HasColumnName("deleted_by");

                                      entity.ToTable("users");

                                      entity.HasData(UserSeeder.Seeds());
                                  });
    }
}