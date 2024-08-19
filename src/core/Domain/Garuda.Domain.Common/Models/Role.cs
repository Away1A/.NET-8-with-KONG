// <copyright file="Role.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using Garuda.Domain.Common.Seeds;
using Garuda.Persistences.Abstract.Contracts;
using Garuda.Persistences.Framework;
using Microsoft.EntityFrameworkCore;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace Garuda.Domain.Common.Models;

public class Role : BaseModel, IEntity, IEntityRegister
{
    /// <summary>
    ///     Gets or sets a value indicating whether gets or Sets for Name.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether gets or Sets for UserRoles.
    /// </summary>
    public IList<UserRole> UserRoles { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether gets or Sets for RoleMenuPermissions.
    /// </summary>
    public IList<RoleMenuPermission> RoleMenuPermissions { get; set; }

    /// <summary>
    ///     Model builder to create it own model to declare field and relation.
    /// </summary>
    /// <param name="modelbuilder"></param>
    public void RegisterEntities(ModelBuilder modelbuilder)
    {
        modelbuilder.Entity<Role>(entity =>
                                  {
                                      entity.HasKey(e => e.Id);

                                      entity.Property(e => e.Id).HasColumnName("id").ValueGeneratedOnAdd();

                                      entity.Property(e => e.Name).HasColumnName("name").HasMaxLength(25);

                                      entity.Property(x => x.CreatedDate).HasColumnName("created_date");

                                      entity.Property(x => x.CreatedBy).HasColumnName("created_by");

                                      entity.Property(x => x.UpdatedDate).HasColumnName("updated_date");

                                      entity.Property(x => x.UpdatedBy).HasColumnName("updated_by");

                                      entity.Property(x => x.DeletedDate).HasColumnName("deleted_date");

                                      entity.Property(x => x.DeletedBy).HasColumnName("deleted_by");

                                      entity.ToTable("roles");

                                      entity.HasData(RoleSeeder.Seeds());
                                  });
    }
}