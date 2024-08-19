// <copyright file="AuditLogHelper.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;

#pragma warning disable CS8602 // Dereference of a possibly null reference.

namespace Garuda.Persistences.Framework.Models.Audits.Configs;

public class AuditLogHelper : RepositoryBase<AuditLog>
{
    private readonly Storage _database;

    /// <summary>
    /// Initializes a new instance of the <see cref="AuditLogHelper"/> class.
    /// </summary>
    /// <param name="db"></param>
    public AuditLogHelper(Storage db)
    {
        this._database = db;
    }

    public void AddAuditLogs(string userName)
    {
        (_database.StorageContext as DbContext)?.ChangeTracker.DetectChanges();
        var auditEntries = new List<AuditLogEntry>();
        foreach (var entry in (_database.StorageContext as DbContext).ChangeTracker.Entries())
        {
            if (entry.Entity is AuditLog || entry.State == EntityState.Detached || entry.State == EntityState.Unchanged)
            {
                continue;
            }

            var auditEntry = new AuditLogEntry(entry, userName);
            auditEntries.Add(auditEntry);
        }

        if (!auditEntries.Any())
        {
            return;
        }

        var logs = auditEntries.Select(x => x.ToAudit());
        SetStorageContext(_database.StorageContext);
        dbSet.AddRange(logs);
    }
}