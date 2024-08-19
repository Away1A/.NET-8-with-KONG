// <copyright file="PageNotFound.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using Garuda.Utilities.Exceptions;

namespace Garuda.Utilities.Constants.Errors;

public partial class Error
{
    public static HttpResponseLibraryException PageNotFound(string? message, object? detail = null)
    {
        throw new HttpResponseLibraryException(HttpStatusCodes.NotFound,
                                               HttpStatusTitles.NotFound,
                                               !string.IsNullOrEmpty(message) ?
                                                   message :
                                                   "Page not found or You dont have permission to access this Menu!",
                                               detail);
    }
}