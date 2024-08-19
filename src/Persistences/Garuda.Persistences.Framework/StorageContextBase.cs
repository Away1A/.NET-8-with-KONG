// <copyright file="StorageContextBase.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using Garuda.Persistences.Abstract.Contracts;
using Garuda.Persistences.Framework.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace Garuda.Persistences.Framework;

public abstract class StorageContextBase : DbContext, IStorageContext
{
    public StorageContextBase(DbContextOptions<StorageContextBase> options)
        : base(options)
    {
    }

    public StorageContextBase(IOptions<StorageContextOptions> options)
    {
        ConnectionString = options.Value.ConnectionString;
        MigrationsAssembly = options.Value.MigrationsAssembly;
    }

    public string ConnectionString { get; }

    public string MigrationsAssembly { get; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        this.RegisterEntities(modelBuilder);
    }
}