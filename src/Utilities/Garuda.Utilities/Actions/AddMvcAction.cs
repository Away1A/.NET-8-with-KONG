// <copyright file="AddMvcAction.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System.Text.Json.Serialization;
using Garuda.Utilities.Contracts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

#pragma warning disable CS8602 // Dereference of a possibly null reference.

namespace Garuda.Utilities.Actions;

public class AddMvcAction : IConfigureServicesAction
{
    public int Priority =>
        1000;

    public void Execute(IServiceCollection services, IServiceProvider serviceProvider)
    {
        var mvcBuilder = services.AddMvc();

        foreach (var assembly in ExtensionManager.Assemblies)
        {
            mvcBuilder.AddApplicationPart(assembly);
        }

        foreach (var action in ExtensionManager.GetInstances<IAddMvcAction>().OrderBy(a => a.Priority))
        {
            var logger = serviceProvider.GetService<ILoggerFactory>().CreateLogger("Garuda.Utilities");

            logger.LogInformation("Executing AddMvc action '{0}'", action.GetType().FullName);
            action.Execute(mvcBuilder, serviceProvider);
        }

        // Configuring endpoint routing for MVC
        services.AddControllers(option =>
                                {
                                    option.EnableEndpointRouting = false;
                                    option.MaxIAsyncEnumerableBufferLimit = 100000;
                                })
                .AddJsonOptions(jsonOptions =>
                                {
                                    // IgnoreNullValues is obsolete.
                                    // jsonOptions.JsonSerializerOptions.IgnoreNullValues = true;
                                    jsonOptions.JsonSerializerOptions.DefaultIgnoreCondition =
                                        JsonIgnoreCondition.WhenWritingNull;
                                })
                .AddNewtonsoftJson(opt =>
                                   {
                                       opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                                       opt.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
                                       opt.SerializerSettings.DateFormatString = "yyyy'-'MM'-'dd' 'HH':'mm':'ss";
                                   });
    }
}