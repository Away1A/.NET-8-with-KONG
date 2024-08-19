// <copyright file="AddAuthAndPolicy.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System.Text;
using Garuda.Utilities.Configurations;
using Garuda.Utilities.Contracts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Garuda.Utilities.Actions
{
    public class AddAuthAndPolicy : IConfigureServicesAction
    {
        public int Priority =>
            1000;

        public void Execute(IServiceCollection services, IServiceProvider serviceProvider)
        {
            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            services.Configure<JwtIssuerOptions>(builder.GetSection("JwtIssuerOptions"));
            var jwtOptions = builder.GetSection(nameof(JwtIssuerOptions));
            var secretKey =
                new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtOptions[nameof(JwtIssuerOptions.SecretKey)] ??
                                                                 "s3creTKeyTempoRadUm!20#4"));
            var issuer = jwtOptions[nameof(JwtIssuerOptions.Issuer)];
            var audience = jwtOptions[nameof(JwtIssuerOptions.Audience)];

            services.AddAuthentication(options =>
                                       {
                                           options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                                           options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                                           options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                                       })
                    .AddJwtBearer(options =>
                                  {
                                      options.IncludeErrorDetails = true;
                                      options.TokenValidationParameters = new TokenValidationParameters
                                      {
                                          ClockSkew = TimeSpan.Zero,
                                          ValidateIssuer = false,
                                          ValidateAudience = false,
                                          ValidateLifetime = true,
                                          ValidateIssuerSigningKey = true,
                                          ValidIssuer = issuer,
                                          ValidAudience = audience,
                                          IssuerSigningKey = secretKey
                                      };
                                  });
        }
    }
}