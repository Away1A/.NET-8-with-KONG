// <copyright file="IConfigureServicesAction.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using Microsoft.Extensions.DependencyInjection;

namespace Garuda.Utilities.Contracts;

/// <summary>
/// Configure Services Action
/// </summary>
public interface IConfigureServicesAction
{
    /// <summary>
    /// Gets priority to executed
    /// </summary>
    int Priority { get; }

    /// <summary>
    /// Execute Services Collection
    /// </summary>
    /// <param name="services"></param>
    /// <param name="serviceProvider"></param>
    void Execute(IServiceCollection services, IServiceProvider serviceProvider);
}