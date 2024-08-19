// <copyright file="AddDatabaseAbstract.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System.Reflection;
using Garuda.Persistences.Abstract.Contracts;
using Garuda.Utilities;
using Garuda.Utilities.Contracts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

#pragma warning disable CS8602 // Dereference of a possibly null reference.

namespace Garuda.Persistences.Abstract.Actions;

public class AddDatabaseAbstract : IConfigureServicesAction
{
    public int Priority =>
        200;

    public void Execute(IServiceCollection services, IServiceProvider serviceProvider)
    {
        var type = ExtensionManager.GetImplementations<IStorage>()
                                   ?.FirstOrDefault(t => !t.GetTypeInfo()
                                                           .IsAbstract);

        if (type == null)
        {
            var logger = serviceProvider.GetService<ILoggerFactory>()
                                        .CreateLogger("Garuda.Abstract");

            logger.LogError("Implementation of Garuda.Abstract not found");
            return;
        }

        services.AddScoped(typeof(IStorage), type);
    }
}