// <copyright file="AddSwagger.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using Garuda.Utilities.Contracts;
using Garuda.Utilities.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.OpenApi.Models;

namespace Garuda.Utilities.Actions
{
    public class AddSwagger : IConfigureServicesAction
    {
        public int Priority =>
            1001;

        public void Execute(IServiceCollection services, IServiceProvider serviceProvider)
        {
            // Configure Swagger
            services.AddApiVersioning()
                    .AddApiExplorer(options =>
                                    {
                                        // Add the versioned API explorer, which also adds IApiVersionDescriptionProvider service
                                        // note: the specified format code will format the version as "'v'major[.minor][-status]"
                                        options.GroupNameFormat = "'v'VVV";

                                        // note: this option is only necessary when versioning by url segment. the SubstitutionFormat
                                        // can also be used to control the format of the API version in route templates
                                        options.SubstituteApiVersionInUrl = true;
                                    });

            services.AddSwaggerGen(options =>
                                   {
                                       options.AddSecurityDefinition("Bearer",
                                                                     new OpenApiSecurityScheme
                                                                     {
                                                                         Scheme = "Bearer",
                                                                         BearerFormat = "JWT",
                                                                         Name = "JWT Authentication",
                                                                         In = ParameterLocation.Header,
                                                                         Type = SecuritySchemeType.Http,
                                                                         Description =
                                                                             "Put **_ONLY_** your JWT Bearer token on textbox below!",
                                                                         Reference = new OpenApiReference
                                                                         {
                                                                             Id = JwtBearerDefaults
                                                                                 .AuthenticationScheme,
                                                                             Type =
                                                                                 ReferenceType.SecurityScheme,
                                                                         },
                                                                     });

                                       options.AddSecurityRequirement(new OpenApiSecurityRequirement
                                       {
                                           {
                                               new OpenApiSecurityScheme
                                               {
                                                   Reference = new OpenApiReference
                                                   {
                                                       Type = ReferenceType
                                                           .SecurityScheme,
                                                       Id = "Bearer"
                                                   }
                                               },
                                               new string[] { }
                                           },
                                       });

                                       options.OperationFilter<SwaggerFileOperationFilter>();

                                       var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                                       foreach (var name in Directory.GetFiles(basePath,
                                                                               "*.XML",
                                                                               SearchOption.AllDirectories))
                                       {
                                           options.IncludeXmlComments(name);
                                       }
                                   });
        }
    }
}