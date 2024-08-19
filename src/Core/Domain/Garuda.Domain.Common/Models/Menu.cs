// <copyright file="Menu.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using Garuda.Domain.Common.Seeds;
using Garuda.Persistences.Abstract.Contracts;
using Garuda.Persistences.Framework;
using Microsoft.EntityFrameworkCore;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace Garuda.Domain.Common.Models;

public class Menu : BaseModel, IEntity, IEntityRegister
{
    /// <summary>
    ///     Gets or sets a value indicating whether gets or Sets for ParentId.
    /// </summary>
    public Guid? ParentId { get; set; } = Guid.Empty;

    /// <summary>
    ///     Gets or sets a value indicating whether gets or Sets for Code.
    /// </summary>
    public string Code { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether gets or Sets for Level.
    /// </summary>
    public string IconClass { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether gets or Sets for DisplayName.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether gets or Sets for Slug.
    /// </summary>
    public string Slug { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether gets or Sets for Level.
    /// </summary>
    public byte Level { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether gets or Sets for DisplayOrder.
    /// </summary>
    public byte Order { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether gets or Sets for Name.
    /// </summary>
    public IList<RoleMenuPermission> RoleMenuPermissions { get; set; } = new List<RoleMenuPermission>();

    /// <summary>
    ///     Model builder to create it own model to declare field and relation.
    /// </summary>
    /// <param name="modelbuilder"></param>
    public void RegisterEntities(ModelBuilder modelbuilder)
    {
        modelbuilder.Entity<Menu>(entity =>
                                  {
                                      entity.HasKey(e => e.Id);

                                      entity.Property(e => e.Id).HasColumnName("id").ValueGeneratedOnAdd();

                                      entity.Property(e => e.Name).HasColumnName("name").HasMaxLength(50).IsRequired();

                                      entity.Property(e => e.Code).HasColumnName("code").HasMaxLength(10).IsRequired();

                                      entity.Property(e => e.Level).HasColumnName("level").IsRequired();

                                      entity.Property(e => e.IconClass).HasColumnName("icon_class").HasMaxLength(20).IsRequired();

                                      entity.Property(e => e.Order).HasColumnName("order");

                                      entity.Property(e => e.Slug).HasColumnName("slug");

                                      entity.Property(x => x.CreatedDate).HasColumnName("created_date");

                                      entity.Property(x => x.CreatedBy).HasColumnName("created_by");

                                      entity.Property(x => x.UpdatedDate).HasColumnName("updated_date");

                                      entity.Property(x => x.UpdatedBy).HasColumnName("updated_by");

                                      entity.Property(x => x.DeletedDate).HasColumnName("deleted_date");

                                      entity.Property(x => x.DeletedBy).HasColumnName("deleted_by");

                                      entity.ToTable("menus");

                                      entity.HasData(MenuSeeder.Seeds());
                                  });
    }
}