// <copyright file="UseEndpointsAction.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using Garuda.Utilities.Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Garuda.Utilities.Actions;

public class UseEndpointsAction : IConfigureAction
{
    public int Priority =>
        1002;

    public void Execute(IApplicationBuilder applicationBuilder, IServiceProvider serviceProvider)
    {
        applicationBuilder.UseAuthentication()
                          .UseRouting()
                          .UseAuthorization()
                          .UseEndpoints(endpointRouteBuilder =>
                                        {
                                            foreach (var action in ExtensionManager.GetInstances<IUseEndpointsAction>()
                                                         .OrderBy(a => a.Priority))
                                            {
                                                var logger = serviceProvider.GetService<ILoggerFactory>()
                                                                            ?.CreateLogger("Garuda.Utilities");

                                                if (logger != null)
                                                {
                                                    logger.LogInformation("Executing UseEndpoints action '{0}'",
                                                                          action.GetType().FullName);
                                                }

                                                action.Execute(endpointRouteBuilder, serviceProvider);
                                            }
                                        });
    }
}