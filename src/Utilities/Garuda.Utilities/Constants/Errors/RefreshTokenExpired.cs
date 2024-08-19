// <copyright file="RefreshTokenExpired.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using Garuda.Utilities.Exceptions;

namespace Garuda.Utilities.Constants.Errors;

public partial class Error
{
    public static HttpResponseLibraryException RefreshTokenExpired(string? message, object? detail = null)
    {
        throw new HttpResponseLibraryException(HttpStatusCodes.Unauthorized,
                                               HttpStatusTitles.Expired,
                                               !string.IsNullOrEmpty(message) ?
                                                   message :
                                                   "Your refresh token has expired. Please generate a new token or re-login",
                                               detail);
    }
}