// <copyright file="DataNotFound.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using Garuda.Utilities.Exceptions;

namespace Garuda.Utilities.Constants.Errors;

public partial class Error
{
    public static HttpResponseLibraryException DataNotFound(string? message = null, object? detail = null)
    {
        throw new HttpResponseLibraryException(HttpStatusCodes.NotFound,
                                               HttpStatusTitles.NotFound,
                                               !string.IsNullOrEmpty(message) ?
                                                   message :
                                                   "The requested resource could not be found",
                                               detail);
    }
}