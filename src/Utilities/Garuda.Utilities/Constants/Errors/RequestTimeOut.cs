// <copyright file="RequestTimeOut.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using Garuda.Utilities.Exceptions;

namespace Garuda.Utilities.Constants.Errors;

public class RequestTimeOut
{
    public static HttpResponseLibraryException RequestTimeout(string? message, object? detail = null)
    {
        throw new HttpResponseLibraryException(HttpStatusCodes.Timeout,
                                               HttpStatusTitles.Timeout,
                                               !string.IsNullOrEmpty(message) ?
                                                   message :
                                                   "Server is taking too long to respond, please try again",
                                               detail);
    }
}