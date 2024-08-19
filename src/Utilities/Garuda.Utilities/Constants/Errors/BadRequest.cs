// <copyright file="BadRequest.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using Garuda.Utilities.Exceptions;

namespace Garuda.Utilities.Constants.Errors;

public partial class Error
{
    public static HttpResponseLibraryException BadRequest(string? message = null, object? detail = null)
    {
        throw new HttpResponseLibraryException(HttpStatusCodes.BadRequest,
                                               HttpStatusTitles.BadRequest,
                                               !string.IsNullOrEmpty(message) ?
                                                   message :
                                                   "The server cannot or will not process the request due to an apparent client error " +
                                                   "(e.g., malformed request syntax, size too large, invalid request message framing, " +
                                                   "or deceptive request routing)",
                                               detail);
    }
}