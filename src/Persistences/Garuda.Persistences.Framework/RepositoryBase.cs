// <copyright file="RepositoryBase.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using Garuda.Persistences.Abstract.Contracts;
using Microsoft.EntityFrameworkCore;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning disable CS8601 // Possible null reference assignment.
#pragma warning disable CS8602 // Dereference of a possibly null reference.

namespace Garuda.Persistences.Framework;

public abstract class RepositoryBase<TEntity> : IRepository
    where TEntity : class, IEntity
{
    protected DbSet<TEntity> dbSet;
    protected DbContext storageContext;

    public void SetStorageContext(IStorageContext sContext)
    {
        this.storageContext = sContext as DbContext;
        dbSet = this.storageContext.Set<TEntity>();
    }
}