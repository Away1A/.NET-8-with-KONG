// <copyright file="JwtMiddleware.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Garuda.Application.Common.Services.V1.Contracts;
using Garuda.Utilities.Configurations;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Garuda.Application.Common.Middleware;

public class JwtMiddleware
{
    private readonly RequestDelegate _next;
    private readonly JwtIssuerOptions _jwtIssuerOptions;

    public JwtMiddleware(RequestDelegate next, IOptions<JwtIssuerOptions> jwtIssuerOptions)
    {
        _next = next;
        _jwtIssuerOptions = jwtIssuerOptions.Value;
    }

    public async Task Invoke(HttpContext context, IUserService userService)
    {
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

        if (token != null)
        {
            await AttachUserToContext(context, userService, token);
        }

        await _next(context);
    }

    private async Task AttachUserToContext(HttpContext context, IUserService userService, string token)
    {
        try
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = _jwtIssuerOptions.Issuer,
                ValidateIssuerSigningKey = true,
                ValidateLifetime = true,
                ValidateAudience = false,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtIssuerOptions.SecretKey))
            };
            tokenHandler.ValidateToken(token, validationParameters, out SecurityToken validatedToken);

            var jwtToken = (JwtSecurityToken)validatedToken;

            context.Items["User"] =
                await userService.GetById(Guid.Parse(jwtToken.Claims.First(x => x.Type == ClaimTypes.NameIdentifier)
                                                             .Value));
        }
        catch
        {
            // do nothing
        }
    }
}