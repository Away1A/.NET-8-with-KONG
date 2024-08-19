// <copyright file="Storage.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using Garuda.Persistences.Abstract.Contracts;
using Garuda.Persistences.Framework.Models.Audits;
using Garuda.Persistences.Framework.Models.Audits.Configs;
using Garuda.Utilities;
using Garuda.Utilities.Constants.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

#pragma warning disable CS8603 // Possible null reference return.
#pragma warning disable CS8602 // Dereference of a possibly null reference.

namespace Garuda.Persistences.Framework;

public class Storage : IStorage
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public Storage(IStorageContext storageContext, IHttpContextAccessor httpContextAccessor)
    {
        if (!(storageContext is DbContext))
        {
            throw new ArgumentException("The storageContext object must be an instance of the " +
                                        "Microsoft.EntityFrameworkCore.DbContext class.");
        }

        StorageContext = storageContext;
        _httpContextAccessor = httpContextAccessor;
    }

    public IStorageContext StorageContext { get; }

    public TRepository GetRepository<TRepository>() where TRepository : IRepository
    {
        var repository = ExtensionManager.GetInstance<TRepository>();

        if (repository != null)
        {
            repository.SetStorageContext(StorageContext);
        }

        return repository;
    }

    public void Save()
    {
        var username = GetAuthenticatedUserName();

        UpdateSoftDeleteStatuses();
        new AuditLogHelper(this).AddAuditLogs(username);
        var strategy = (StorageContext as DbContext).Database.CreateExecutionStrategy();
        strategy.Execute(() =>
                         {
                             using var transact = (StorageContext as DbContext).Database.BeginTransaction();
                             try
                             {
                                 (StorageContext as DbContext).SaveChanges();
                                 transact.Commit();
                             }
                             catch (Exception ex)
                             {
                                 transact.Rollback();
                                 throw Error.BadRequest(ex.Message);
                             }
                         });
    }

    public async Task SaveAsync()
    {
        var username = GetAuthenticatedUserName();

        UpdateSoftDeleteStatuses();
        (StorageContext as DbContext).Database.CreateExecutionStrategy();
        new AuditLogHelper(this).AddAuditLogs(username);
        var strategy = (StorageContext as DbContext).Database.CreateExecutionStrategy();
        await strategy.ExecuteAsync(async () =>
                                    {
                                        await using var transact =
                                            await (StorageContext as DbContext).Database.BeginTransactionAsync();
                                        try
                                        {
                                            await (StorageContext as DbContext).SaveChangesAsync();
                                            await transact.CommitAsync();
                                        }
                                        catch (Exception ex)
                                        {
                                            await transact.RollbackAsync();
                                            throw Error.BadRequest(ex.Message);
                                        }
                                    });
    }

    private void UpdateSoftDeleteStatuses()
    {
        var user = GetAuthenticatedUserName();
        foreach (var entry in (StorageContext as DbContext).ChangeTracker.Entries())
        {
            if (entry.Entity is AuditLog || entry.State == EntityState.Detached || entry.State == EntityState.Unchanged)
            {
                continue;
            }

            switch (entry.State)
            {
                case EntityState.Added:
                    entry.CurrentValues["CreatedDate"] = DateTime.UtcNow;
                    entry.CurrentValues["CreatedBy"] = user;
                    entry.CurrentValues["DeletedDate"] = null;
                    entry.CurrentValues["UpdatedDate"] = null;
                    entry.CurrentValues["UpdatedBy"] = null;
                    break;
                case EntityState.Modified:
                    entry.CurrentValues["UpdatedDate"] = DateTime.UtcNow;
                    entry.CurrentValues["UpdatedBy"] = user;
                    break;
                case EntityState.Deleted:
                    entry.State = EntityState.Modified;
                    entry.CurrentValues["DeletedDate"] = DateTime.UtcNow;
                    entry.CurrentValues["DeletedBy"] = user;
                    break;
            }
        }
    }

    private string GetAuthenticatedUserName()
    {
        dynamic? user = _httpContextAccessor.HttpContext.Items["User"];
        return user != null ? user.Fullname : "System";
    }
}