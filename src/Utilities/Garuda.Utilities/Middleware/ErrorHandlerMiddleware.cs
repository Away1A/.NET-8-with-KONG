// <copyright file="ErrorHandlerMiddleware.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using Garuda.Utilities.Constants.Errors;
using Garuda.Utilities.Exceptions;
using Garuda.Utilities.Helpers;
using Microsoft.AspNetCore.Http;

namespace Garuda.Utilities.Middleware;

public class ErrorHandlerMiddleware
{
    private readonly RequestDelegate _next;

    /// <summary>
    /// Initializes a new instance of the <see cref="ErrorHandlerMiddleware"/> class.
    /// </summary>
    /// <param name="next"></param>
    public ErrorHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception error)
        {
            Console.WriteLine(error.ToString());

            var response = context.Response;
            response.ContentType = "application/json";

            switch (error)
            {
                case HttpResponseLibraryException e:
                    response.StatusCode = e.Status;
                    await response.WriteAsJsonAsync(e.TransformErrorPayload());
                    break;
                default:
                    response.StatusCode = Error.BadRequest().Status;
                    await response.WriteAsJsonAsync(Error.BadRequest().TransformErrorPayload());
                    break;
            }
        }
    }
}