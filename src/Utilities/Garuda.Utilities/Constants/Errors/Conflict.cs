// <copyright file="Conflict.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using Garuda.Utilities.Exceptions;

namespace Garuda.Utilities.Constants.Errors;

public partial class Error
{
    public static HttpResponseLibraryException Conflict(string? message = null, object? detail = null)
    {
        throw new HttpResponseLibraryException(HttpStatusCodes.Conflict,
                                               HttpStatusTitles.Duplicate,
                                               !string.IsNullOrEmpty(message) ?
                                                   message :
                                                   "The server cannot or will not process the request due to an apparent client error " +
                                                   "(e.g., malformed request syntax, size too large, invalid request message framing, " +
                                                   "or deceptive request routing)",
                                               detail);
    }
}