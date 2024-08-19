// <copyright file="RoleNotAppropriated.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using Garuda.Utilities.Exceptions;

namespace Garuda.Utilities.Constants.Errors;

public partial class Error
{
    public static HttpResponseLibraryException RoleNotApproriated(string? message, object? detail = null)
    {
        throw new HttpResponseLibraryException(HttpStatusCodes.Forbidden,
                                               HttpStatusTitles.Forbidden,
                                               !string.IsNullOrEmpty(message) ? message : "The role is not appropriate",
                                               detail);
    }
}