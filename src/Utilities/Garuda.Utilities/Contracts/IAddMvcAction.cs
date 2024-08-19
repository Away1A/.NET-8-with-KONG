// <copyright file="IAddMvcAction.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using Microsoft.Extensions.DependencyInjection;

namespace Garuda.Utilities.Contracts;

/// <summary>
/// MVC Action
/// </summary>
public interface IAddMvcAction
{
    /// <summary>
    /// Gets priority to be executed
    /// </summary>
    int Priority { get; }

    /// <summary>
    /// Execute Service provider on modular
    /// </summary>
    /// <param name="mvcBuilder"></param>
    /// <param name="serviceProvider"></param>
    void Execute(IMvcBuilder mvcBuilder, IServiceProvider serviceProvider);
}