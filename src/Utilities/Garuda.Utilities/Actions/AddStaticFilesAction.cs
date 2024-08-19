// <copyright file="AddStaticFilesAction.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using Garuda.Utilities.Contracts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;

#pragma warning disable CS8602 // Dereference of a possibly null reference.

namespace Garuda.Utilities.Actions;

public class AddStaticFilesAction : IConfigureServicesAction
{
    public int Priority =>
        1000;

    public void Execute(IServiceCollection services, IServiceProvider serviceProvider)
    {
        serviceProvider.GetService<IWebHostEnvironment>().WebRootFileProvider =
            CreateCompositeFileProvider(serviceProvider);
    }

    private IFileProvider CreateCompositeFileProvider(IServiceProvider serviceProvider)
    {
        IFileProvider[] fileProviders = [serviceProvider.GetService<IWebHostEnvironment>().WebRootFileProvider];

        return new CompositeFileProvider(fileProviders.Concat(ExtensionManager.Assemblies.Select(a =>
                                                                  new EmbeddedFileProvider(a,
                                                                   a.GetName().Name))));
    }
}