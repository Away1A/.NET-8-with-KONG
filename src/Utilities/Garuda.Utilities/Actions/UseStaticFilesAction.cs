// <copyright file="UseStaticFilesAction.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using Garuda.Utilities.Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Garuda.Utilities.Actions;

public class UseStaticFilesAction : IConfigureAction
{
    public int Priority =>
        1000;

    public void Execute(IApplicationBuilder applicationBuilder, IServiceProvider serviceProvider)
    {
        var options = serviceProvider.GetService<IOptions<StaticFileOptions>>();

        if (options?.Value != null)
        {
            applicationBuilder.UseStaticFiles(options.Value);
        }
    }
}