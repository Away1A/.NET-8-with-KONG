// <copyright file="AddSieveAction.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using Garuda.Utilities.Contracts;
using Garuda.Utilities.Helpers;
using Garuda.Utilities.Sieves;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sieve.Models;
using Sieve.Services;

namespace Garuda.Utilities.Actions;

public class AddSieveAction : IConfigureServicesAction
{
    public int Priority =>
        1000;

    public void Execute(IServiceCollection services, IServiceProvider serviceProvider)
    {
        var builder = new ConfigurationBuilder().SetBasePath(GlobalConfiguration.ContentRootPath)
                                                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
        var configuration = builder.Build();
        services.Configure<SieveOptions>(options => configuration.GetSection("Sieve").Bind(options));
        services.AddScoped(_ =>
                           {
                               var type = typeof(ISieveCustomFilterMethods);
                               var types = AppDomain.CurrentDomain.GetAssemblies()
                                                    .SelectMany(x => x.GetExportedTypes())
                                                    .Where(x => type.IsAssignableFrom(x))
                                                    .ToArray();

                               Type compositeSieve = CompositeSieveCustomFilterBuilder.Build(types);
                               object? instance = Activator.CreateInstance(compositeSieve);

                               if (instance == null)
                               {
                                   throw new Exception("Activator.CreateInstance(compositeSieve) returned null!");
                               }

                               return (ISieveCustomFilterMethods)instance;
                           });

        services.AddScoped(_ =>
                           {
                               var type = typeof(ISieveCustomSortMethods);
                               var types = AppDomain.CurrentDomain.GetAssemblies()
                                                    .SelectMany(x => x.GetExportedTypes())
                                                    .Where(x => type.IsAssignableFrom(x))
                                                    .ToArray();

                               Type compositeSieve = CompositeSieveCustomSortBuilder.Build(types);
                               object? instance = Activator.CreateInstance(compositeSieve);
                               if (instance == null)
                               {
                                   throw new Exception("Activator.CreateInstance(compositeSieve) returned null!");
                               }

                               return (ISieveCustomSortMethods)instance;
                           });

        services.AddScoped<ISieveProcessor, ApplicationSieveProcessor>();
        services.AddScoped<SieveProcessor>();
    }
}