// <copyright file="IUseEndpointsAction.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Routing;

namespace Garuda.Utilities.Contracts;

/// <summary>
/// Endpoint Action interface
/// </summary>
public interface IUseEndpointsAction
{
    /// <summary>
    /// Gets priority to executed
    /// </summary>
    int Priority { get; }

    /// <summary>
    /// Execute endpoint builder within module
    /// </summary>
    /// <param name="endpointRouteBuilder"></param>
    /// <param name="serviceProvider"></param>
    void Execute(IEndpointRouteBuilder endpointRouteBuilder, IServiceProvider serviceProvider);
}