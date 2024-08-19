// <copyright file="AuditLogEntry.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning disable CS8629 // Nullable value type may be null.
#pragma warning disable CS8601 // Possible null reference assignment.

namespace Garuda.Persistences.Framework.Models.Audits.Configs;

public class AuditLogEntry
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AuditLogEntry"/> class.
    /// </summary>
    /// <param name="entry"></param>
    /// <param name="auditUser"></param>
    public AuditLogEntry(EntityEntry entry, string auditUser)
    {
        Entry = entry;
        AuditUser = auditUser;
        SetChanges();
    }

    public EntityEntry Entry { get; }

    public string Action { get; set; }

    public string AuditUser { get; set; }

    public string ClassName { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string UpdatedBy { get; set; }

    public DateTime? DeletedDate { get; set; }

    public string DeletedBy { get; set; }

    public Dictionary<string, object> OldValues { get; } = new();

    public Dictionary<string, object> NewValues { get; } = new();

    public AuditLog ToAudit()
    {
        var audit = new AuditLog
        {
            Id = Guid.NewGuid(),
            ClassName = ClassName,
            Action = Action,
            Description = string.Empty,
            OldValue = OldValues.Count == 0 ? null : JsonConvert.SerializeObject(OldValues),
            NewValue = NewValues.Count == 0 ? null : JsonConvert.SerializeObject(NewValues),
            CreatedDate = DateTime.UtcNow,
            UpdatedDate = UpdatedDate.Value,
            DeletedDate = DeletedDate,
            CreatedBy = AuditUser,
            UpdatedBy = UpdatedBy,
            DeletedBy = DeletedBy,
        };

        return audit;
    }

    private void SetChanges()
    {
        ClassName = Entry.Metadata.Name;
        foreach (var property in Entry.Properties)
        {
            var propertyName = property.Metadata.Name;

            switch (Entry.State)
            {
                case EntityState.Added:
                    NewValues[propertyName] = property.CurrentValue;
                    Action = "CREATE";
                    UpdatedDate = DateTime.UtcNow;
                    UpdatedBy = AuditUser;
                    break;

                case EntityState.Deleted:
                    OldValues[propertyName] = property.OriginalValue;
                    Action = "DELETE";
                    DeletedDate = DateTime.UtcNow;
                    DeletedBy = AuditUser;
                    break;

                case EntityState.Modified:
                    if (property.IsModified)
                    {
                        OldValues[propertyName] = property.OriginalValue;
                        NewValues[propertyName] = property.CurrentValue;
                        Action = "UPDATE";
                        UpdatedDate = DateTime.UtcNow;
                        UpdatedBy = AuditUser;
                    }

                    break;
            }
        }
    }
}