// <copyright file="InvalidCredential.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using Garuda.Utilities.Exceptions;

namespace Garuda.Utilities.Constants.Errors;

public partial class Error
{
    public static HttpResponseLibraryException InvalidCredential(string? message = null, object? detail = null)
    {
        throw new HttpResponseLibraryException(HttpStatusCodes.InvalidCredential,
                                               HttpStatusTitles.Invalid,
                                               !string.IsNullOrEmpty(message) ?
                                                   message :
                                                   "Invalid username or password",
                                               detail);
    }
}