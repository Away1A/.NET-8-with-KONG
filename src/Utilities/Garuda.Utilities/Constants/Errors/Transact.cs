// <copyright file="Transact.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using Garuda.Utilities.Exceptions;

namespace Garuda.Utilities.Constants.Errors;

public partial class Error
{
    public static HttpResponseLibraryException Transaction(string? message = null, object? detail = null)
    {
        throw new HttpResponseLibraryException(HttpStatusCodes.ErrorTransaction,
                                               HttpStatusTitles.Failed,
                                               !string.IsNullOrEmpty(message) ?
                                                   message :
                                                   "Process data failed. please check logs to see the exceptions",
                                               detail);
    }
}