// <copyright file="AddCors.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using Garuda.Utilities.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

#pragma warning disable CS8602 // Dereference of a possibly null reference.

namespace Garuda.Utilities.Actions
{
    public class AddCors : IConfigureServicesAction
    {
        public int Priority =>
            1000;

        public void Execute(IServiceCollection services, IServiceProvider serviceProvider)
        {
            var builder = new ConfigurationBuilder().SetBasePath(GlobalConfiguration.ContentRootPath)
                                                    .AddJsonFile("appsettings.json",
                                                                 optional: false,
                                                                 reloadOnChange: true);

            var configuration = builder.Build();

            // Configure Cors Policy
            services.AddCors(o =>
                             {
                                 o.AddPolicy("_customAllowSpecificOrigins",
                                             corsPolicyBuilder =>
                                             {
                                                 corsPolicyBuilder.WithOrigins(configuration["AllowedHosts"].Split(","))
                                                                  .AllowAnyHeader()
                                                                  .AllowAnyMethod();
                                             });
                             });
        }
    }
}