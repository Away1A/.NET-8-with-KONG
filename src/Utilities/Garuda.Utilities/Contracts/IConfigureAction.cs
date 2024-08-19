﻿// <copyright file="IConfigureAction.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Builder;

namespace Garuda.Utilities.Contracts;

/// <summary>
/// Configure Action
/// </summary>
public interface IConfigureAction
{
    /// <summary>
    /// Gets priorty to be executed
    /// </summary>
    int Priority { get; }

    /// <summary>
    /// Execute Service provider to build
    /// </summary>
    /// <param name="applicationBuilder"></param>
    /// <param name="serviceProvider"></param>
    void Execute(IApplicationBuilder applicationBuilder, IServiceProvider serviceProvider);
}