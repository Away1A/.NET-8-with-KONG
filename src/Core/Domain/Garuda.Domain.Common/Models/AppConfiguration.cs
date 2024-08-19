// <copyright file="AppConfiguration.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using Garuda.Persistences.Abstract.Contracts;
using Garuda.Persistences.Framework;
using Microsoft.EntityFrameworkCore;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace Garuda.Domain.Common.Models;

public class AppConfiguration : BaseModel, IEntity, IEntityRegister
{
    /// <summary>
    ///     Gets or sets a value indicating whether gets or Sets for Key.
    /// </summary>
    public string Key { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether gets or Sets for Value.
    /// </summary>
    public string Value { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether gets or Sets for Description.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    ///     Model builder to create it own model to declare field and relation.
    /// </summary>
    /// <param name="modelbuilder"></param>
    public void RegisterEntities(ModelBuilder modelbuilder)
    {
        modelbuilder.Entity<AppConfiguration>(entity =>
                                              {
                                                  entity.HasKey(x => x.Id);

                                                  entity.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();

                                                  entity.Property(x => x.Key).HasColumnName("key").HasMaxLength(50);

                                                  entity.Property(x => x.Value)
                                                        .HasColumnName("value")
                                                        .HasMaxLength(8000);

                                                  entity.Property(x => x.CreatedDate).HasColumnName("created_date");

                                                  entity.Property(x => x.CreatedBy).HasColumnName("created_by");

                                                  entity.Property(x => x.UpdatedDate).HasColumnName("updated_date");

                                                  entity.Property(x => x.UpdatedBy).HasColumnName("updated_by");

                                                  entity.Property(x => x.DeletedDate).HasColumnName("deleted_date");

                                                  entity.Property(x => x.DeletedBy).HasColumnName("deleted_by");

                                                  entity.ToTable("app_configurations");
                                              });
    }
}