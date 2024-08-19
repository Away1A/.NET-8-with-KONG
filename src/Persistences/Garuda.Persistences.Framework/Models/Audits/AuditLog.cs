// <copyright file="AuditLog.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using Garuda.Persistences.Abstract.Contracts;
using Microsoft.EntityFrameworkCore;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace Garuda.Persistences.Framework.Models.Audits;

public class AuditLog : BaseModel, IEntity, IEntityRegister
{
    public string ClassName { get; set; }

    public string Action { get; set; }

    public string Description { get; set; }

    public string OldValue { get; set; }

    public string NewValue { get; set; }

    public void RegisterEntities(ModelBuilder modelbuilder)
    {
        modelbuilder.Entity<AuditLog>(entity =>
                                      {
                                          entity.ToTable("audit_logs");

                                          entity.Property(e => e.Id).HasColumnName("id");

                                          entity.Property(e => e.ClassName).HasColumnName("class_name");

                                          entity.Property(e => e.Action).HasColumnName("action");

                                          entity.Property(e => e.Description).HasColumnName("description");

                                          entity.Property(e => e.OldValue).IsRequired(false).HasColumnName("old_value");

                                          entity.Property(e => e.NewValue).HasColumnName("new_value");

                                          entity.Property(x => x.CreatedDate).HasColumnName("created_date");

                                          entity.Property(x => x.CreatedBy).HasColumnName("created_by");

                                          entity.Property(x => x.UpdatedDate).HasColumnName("updated_date");

                                          entity.Property(x => x.UpdatedBy).HasColumnName("updated_by");

                                          entity.Property(x => x.DeletedDate).HasColumnName("deleted_date");

                                          entity.Property(x => x.DeletedBy).HasColumnName("deleted_by");
                                      });
    }
}