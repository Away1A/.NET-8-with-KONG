// <copyright file="AddModulesCommon.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using Garuda.Utilities.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace Garuda.Presentation.Common.Actions;

public class AddModulesCommon : IConfigureServicesAction
{
    public int Priority =>
        1000;

    public void Execute(IServiceCollection services, IServiceProvider serviceProvider)
    {
    }
}