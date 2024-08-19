// <copyright file="Unauthorized.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using Garuda.Utilities.Exceptions;

namespace Garuda.Utilities.Constants.Errors;

public partial class Error
{
    public static HttpResponseLibraryException Unauthorized(string? message = null, object? detail = null)
    {
        throw new HttpResponseLibraryException(HttpStatusCodes.Unauthorized,
                                               HttpStatusTitles.Unauthorized,
                                               !string.IsNullOrEmpty(message) ?
                                                   message :
                                                   "You do not have required permissions to perform this action.",
                                               detail);
    }
}