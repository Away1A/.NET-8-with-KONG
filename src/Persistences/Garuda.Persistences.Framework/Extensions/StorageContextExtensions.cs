// <copyright file="StorageContextExtensions.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using Garuda.Persistences.Abstract.Contracts;
using Garuda.Utilities;
using Microsoft.EntityFrameworkCore;

namespace Garuda.Persistences.Framework.Extensions;

public static class StorageContextExtensions
{
    public static void RegisterEntities(this IStorageContext storageContext, ModelBuilder modelBuilder)
    {
        foreach (var entityRegistrar in ExtensionManager.GetInstances<IEntityRegister>())
        {
            entityRegistrar.RegisterEntities(modelBuilder);
        }
    }
}