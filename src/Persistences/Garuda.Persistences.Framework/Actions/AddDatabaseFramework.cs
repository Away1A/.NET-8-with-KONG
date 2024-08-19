// <copyright file="AddDatabaseFramework.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System.Reflection;
using Garuda.Persistences.Abstract.Contracts;
using Garuda.Utilities;
using Garuda.Utilities.Contracts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

#pragma warning disable CS8604 // Possible null reference argument.

namespace Garuda.Persistences.Framework.Actions;

public class AddDatabaseFramework : IConfigureServicesAction
{
    public int Priority =>
        200;

    public void Execute(IServiceCollection services, IServiceProvider serviceProvider)
    {
        var type = ExtensionManager.GetImplementations<IStorageContext>()
                                   ?.FirstOrDefault(t => !t.GetTypeInfo().IsAbstract);

        if (type == null)
        {
            var logger = serviceProvider.GetService<ILoggerFactory>()?.CreateLogger("Garuda.Persistences.Framework");

            logger.LogError("Implementation of Garuda.Database.Abstract.Contracts.IStorageContext not found");
            return;
        }

        services.AddScoped(typeof(IStorageContext), type);
    }
}