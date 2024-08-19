// <copyright file="UnsupportedMediaType.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using Garuda.Utilities.Exceptions;

namespace Garuda.Utilities.Constants.Errors;

public partial class Error
{
    public static HttpResponseLibraryException UnsupportedMediaType(string? message, object? detail = null)
    {
        throw new HttpResponseLibraryException(HttpStatusCodes.UnsupportedMediaType,
                                               HttpStatusTitles.UnsupportedMediaType,
                                               !string.IsNullOrEmpty(message) ?
                                                   message :
                                                   "Payload format is not supported.",
                                               detail);
    }
}