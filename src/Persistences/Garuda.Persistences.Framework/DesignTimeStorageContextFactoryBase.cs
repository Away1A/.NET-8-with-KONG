// <copyright file="DesignTimeStorageContextFactoryBase.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using Garuda.Persistences.Abstract.Contracts;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;

#pragma warning disable CS8601 // Possible null reference assignment.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace Garuda.Persistences.Framework;

public abstract class DesignTimeStorageContextFactoryBase<T> : IDesignTimeDbContextFactory<T>
    where T : StorageContextBase
{
    public static T StorageContext { get; set; }

    public static void Initialize(IServiceProvider serviceProvider)
    {
        StorageContext = serviceProvider.GetService<IStorageContext>() as T;
    }

    public T CreateDbContext(string[] args)
    {
        return StorageContext;
    }
}