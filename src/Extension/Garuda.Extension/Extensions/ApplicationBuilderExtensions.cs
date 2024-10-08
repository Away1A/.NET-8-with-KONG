﻿// <copyright file="ApplicationBuilderExtensions.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using Garuda.Utilities;
using Garuda.Utilities.Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Garuda.Extension.Extensions;

public static class ApplicationBuilderExtensions
{
    public static void UseGarudaCore(this IApplicationBuilder applicationBuilder)
    {
        var logger = applicationBuilder.ApplicationServices.GetService<ILoggerFactory>()
                                       ?.CreateLogger("Garuda.Extension");

        foreach (var action in ExtensionManager.GetInstances<IConfigureAction>().OrderBy(a => a.Priority))
        {
            logger?.LogInformation("Executing Configure action '{0}'", action.GetType().FullName);
            action.Execute(applicationBuilder, applicationBuilder.ApplicationServices);
        }
    }
}