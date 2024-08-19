// <copyright file="ConfiguresServicesAction.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using Garuda.Persistences.Abstract.Contracts;
using Garuda.Utilities.Contracts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

#pragma warning disable CS8602 // Dereference of a possibly null reference.

namespace Garuda.Persistences.MsSql.Actions;

public class ConfiguresServicesAction : IConfigureServicesAction
{
    public int Priority =>
        200;

    public void Execute(IServiceCollection services, IServiceProvider serviceProvider)
    {
        var configurationBuilder = new ConfigurationBuilder()
                                   .SetBasePath(serviceProvider.GetService<IWebHostEnvironment>().ContentRootPath)
                                   .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

        services.AddDbContext<StorageContext>(options => options.UseSqlServer(configurationBuilder.Build()
                                                                                  .GetConnectionString("Connection")));

        services.AddScoped(typeof(IStorageContext), typeof(StorageContext));
    }
}