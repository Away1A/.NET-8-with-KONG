// <copyright file="RoleMenuPermission.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using Garuda.Domain.Common.Seeds;
using Garuda.Persistences.Abstract.Contracts;
using Garuda.Persistences.Framework;
using Microsoft.EntityFrameworkCore;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace Garuda.Domain.Common.Models;

public class RoleMenuPermission : BaseModel, IEntity, IEntityRegister
{
    /// <summary>
    ///     Gets or sets a value indicating whether gets or Sets for MenuId.
    /// </summary>
    public Guid MenuId { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether gets or Sets for GroupId.
    /// </summary>
    public Guid RoleId { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether gets or Sets for CanView.
    /// </summary>
    public bool CanView { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether gets or Sets for CanUpdate.
    /// </summary>
    public bool CanUpdate { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether gets or Sets for CanCreate.
    /// </summary>
    public bool CanCreate { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether gets or Sets for CanDelete.
    /// </summary>
    public bool CanDelete { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether gets or Sets for Group.
    /// </summary>
    public Role Role { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether gets or Sets for Menu.
    /// </summary>
    public Menu Menu { get; set; }

    /// <summary>
    ///     Model builder to create it own model to declare field and relation.
    /// </summary>
    /// <param name="modelbuilder"></param>
    public void RegisterEntities(ModelBuilder modelbuilder)
    {
        modelbuilder.Entity<RoleMenuPermission>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id).HasColumnName("id")
                .ValueGeneratedOnAdd();

            entity.Property(e => e.RoleId).HasColumnName("role_id");

            entity.Property(e => e.MenuId).HasColumnName("menu_id");

            entity.HasOne(e => e.Role)
                .WithMany(e => e.RoleMenuPermissions)
                .HasForeignKey(e => e.RoleId);

            entity.HasOne(e => e.Menu)
                .WithMany(e => e.RoleMenuPermissions)
                .HasForeignKey(e => e.MenuId);

            entity.Property(e => e.CanCreate).HasColumnName("can_create");

            entity.Property(e => e.CanDelete).HasColumnName("can_delete");

            entity.Property(e => e.CanUpdate).HasColumnName("can_update");

            entity.Property(e => e.CanView).HasColumnName("can_view");

            entity.Property(x => x.CreatedDate).HasColumnName("created_date");

            entity.Property(x => x.CreatedBy).HasColumnName("created_by");

            entity.Property(x => x.UpdatedDate).HasColumnName("updated_date");

            entity.Property(x => x.UpdatedBy).HasColumnName("updated_by");

            entity.Property(x => x.DeletedDate).HasColumnName("deleted_date");

            entity.Property(x => x.DeletedBy).HasColumnName("deleted_by");

            entity.ToTable("role_menu_permissions");

            entity.HasData(RoleMenuPermissionSeeder.Seeds());
        });
    }
}