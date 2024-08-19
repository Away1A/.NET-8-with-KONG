// <copyright file="AuthorizeApiAttribute.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System.Security.Claims;
using Garuda.Utilities.Configurations;
using Garuda.Utilities.Constants.Errors;
using Microsoft.AspNetCore.Mvc.Filters;

#pragma warning disable CS8604 // Possible null reference argument.

namespace Garuda.Utilities.Middleware;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
public class AuthorizeApiAttribute(params string[] parameter) : AuthorizeAttribute, IAuthorizationFilter
{
    public new void OnAuthorization(AuthorizationFilterContext context)
    {
        var userId = context.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        var menus = PermissionDictionary.Permissions.FirstOrDefault(x => x.Key == Guid.Parse(userId));
        if (menus.Value.Any(parameter.Contains))
        {
            return;
        }

        throw Error.Unauthorized();
    }
}