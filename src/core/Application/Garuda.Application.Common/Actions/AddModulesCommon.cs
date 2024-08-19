// <copyright file="AddModulesCommon.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System.Reflection;
using System.Transactions;
using Garuda.Application.Common.Services.V1;
using Garuda.Application.Common.Services.V1.Contracts;
using Garuda.Application.Common.Sieves;
using Garuda.Utilities.Contracts;
using Mapster;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;
using Sieve.Services;

namespace Garuda.Application.Common.Actions;

public class AddModulesCommon : IConfigureServicesAction
{
    public int Priority =>
        1000;

    public void Execute(IServiceCollection services, IServiceProvider serviceProvider)
    {
        var config = TypeAdapterConfig.GlobalSettings;
        config.Scan(Assembly.GetExecutingAssembly());
        services.AddSingleton(config);
        services.AddScoped<IMapper, ServiceMapper>();
        services.AddScoped<ISieveCustomFilterMethods, SieveCommonFilter>();
        services.AddScoped<ISieveCustomSortMethods, SieveCommonSort>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IMenuService, MenuService>();
        services.AddScoped<IRoleService, RoleService>();
        services.AddScoped<IRoleMenuPermissionService, RoleMenuPermissionService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IAnimalService, AnimalService>();
    }
}