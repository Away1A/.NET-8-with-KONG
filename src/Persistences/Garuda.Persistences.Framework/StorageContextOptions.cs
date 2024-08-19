// <copyright file="StorageContextOptions.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
namespace Garuda.Persistences.Framework;

public class StorageContextOptions
{
    public string ConnectionString { get; set; }

    public string ConnectionStringBridging { get; set; }

    public string MigrationsAssembly { get; set; }
}