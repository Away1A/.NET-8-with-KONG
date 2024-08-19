// <copyright file="PayloadTooLarge.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using Garuda.Utilities.Exceptions;

namespace Garuda.Utilities.Constants.Errors;

public partial class Error
{
    public static HttpResponseLibraryException PayloadTooLarge(string? message, object? detail = null)
    {
        throw new HttpResponseLibraryException(HttpStatusCodes.PayloadTooLarge,
                                               HttpStatusTitles.PayloadTooLarge,
                                               !string.IsNullOrEmpty(message) ?
                                                   message :
                                                   "Size of a request exceeds the server's file size limit.",
                                               detail);
    }
}