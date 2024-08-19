// <copyright file="ConfigureServicesAction.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using Garuda.Providers.Auth.LDAP.Configurations;
using Garuda.Utilities.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Novell.Directory.Ldap;

namespace Garuda.Providers.Auth.LDAP.Actions;

public class ConfigureServicesAction : IConfigureServicesAction
{
    public int Priority =>
        1000;

    public void Execute(IServiceCollection services, IServiceProvider serviceProvider)
    {
        var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
        var configuration = builder.Build();

        services.Configure<LdapLibraryConfig>(configuration.GetSection("Ldap"));
        services.AddScoped<ILdapConnection, LdapConnection>();
    }
}