// <copyright file="ConfigureServicesAction.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using Garuda.Utilities.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace Garuda.Providers.Auth.Abstract.Action;

public class ConfigureServicesAction : IConfigureServicesAction
{
    public int Priority => 100;

    public void Execute(IServiceCollection services, IServiceProvider serviceProvider)
    {
    }
}