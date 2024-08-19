// <copyright file="Inactive.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using Garuda.Utilities.Exceptions;

namespace Garuda.Utilities.Constants.Errors;

public partial class Error
{
    public static HttpResponseLibraryException Inactive(string? message, object? detail = null)
    {
        throw new HttpResponseLibraryException(HttpStatusCodes.Unauthorized,
                                               HttpStatusTitles.Inactive,
                                               !string.IsNullOrEmpty(message) ?
                                                   message :
                                                   "Data is no longer active. Please contact your administrator.",
                                               detail);
    }
}