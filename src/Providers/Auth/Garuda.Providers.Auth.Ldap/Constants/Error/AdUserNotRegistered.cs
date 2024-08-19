// <copyright file="AdUserNotRegistered.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using Garuda.Utilities.Constants;
using Garuda.Utilities.Exceptions;

namespace Garuda.Providers.Auth.LDAP.Constants.Error;

public partial class Error
{
    public static readonly HttpResponseLibraryException AdUserNotRegistered =
        new(HttpStatusCodes.Unauthorized,
            "UNAUTHRORIZED",
            "Account is not registered. Please contact your administrator.");
}