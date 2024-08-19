// <copyright file="Program.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System.Reflection;
using Garuda.Application.Common.Middleware;
using Garuda.Extension.Extensions;
using Garuda.Migrations;
using Garuda.Persistences.Framework;
using Garuda.Utilities;
using Garuda.Utilities.Middleware;
using Mapster;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Serilog;

#pragma warning disable CS8604 // Possible null reference argument.
#pragma warning disable SA1516 // Elements should be separated by blank line.

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;
var environment = builder.Environment;
var serilog = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();

GlobalConfiguration.WebRootPath = environment.WebRootPath;
GlobalConfiguration.ContentRootPath = environment.ContentRootPath;

// load Configuration
services.AddGarudaCore(GlobalConfiguration.ContentRootPath, true);

// Configure Migration on HOST
services.Configure<StorageContextOptions>(options =>
                                          {
                                              options.ConnectionString =
                                                  configuration.GetConnectionString("Connection") ??
                                                  throw new InvalidOperationException();
                                              options.MigrationsAssembly =
                                                  typeof(DesignTimeStorageContextFactory).GetTypeInfo()
                                                      .Assembly.FullName ??
                                                  string.Empty;
                                          });

// Add Serilog
services.AddSerilog(serilog);

TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetEntryAssembly());

if (services != null)
{
#pragma warning disable ASP0000
    DesignTimeStorageContextFactory.Initialize(builder.Services.BuildServiceProvider());
#pragma warning restore ASP0000
}

services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

var app = builder.Build();

app.UseMiddleware<ErrorHandlerMiddleware>();
app.UseMiddleware<JwtMiddleware>();
app.UseStatusCodePages();
app.UseCookiePolicy();
app.UseCors(policyBuilder => policyBuilder.WithOrigins("*").AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

if (!environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
                     {
                         options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                         options.RoutePrefix = string.Empty;
                     });
}

app.UseGarudaCore();
app.UseStaticFiles();
app.MapControllers();

app.Run();