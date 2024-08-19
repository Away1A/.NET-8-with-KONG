// <copyright file="SwaggerFileOperationFilter.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Http;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Garuda.Utilities.Helpers;

public class SwaggerFileOperationFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        var fileUploadMime = "multipart/form-data";
        if (operation.RequestBody == null ||
            !operation.RequestBody.Content.Any(x => x.Key.Equals(fileUploadMime,
                                                                 StringComparison.InvariantCultureIgnoreCase)))
        {
            return;
        }

        var fileParams = context.MethodInfo.GetParameters().Where(p => p.ParameterType == typeof(IFormFile));
        Dictionary<string, OpenApiSchema> dictionary = new();
        foreach (var param in fileParams)
        {
            if (param.Name != null)
            {
                dictionary.Add(param.Name, new OpenApiSchema { Type = "string", Format = "binary", });
            }
        }

        operation.RequestBody.Content[fileUploadMime].Schema.Properties = dictionary;
    }
}