// <copyright file="TransformErrorToPayload.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using Garuda.Utilities.Exceptions;

namespace Garuda.Utilities.Helpers;

public static class TransformErrorToPayload
{
    public static object TransformErrorPayload(this HttpResponseLibraryException error)
    {
        return new { error.Status, error.Title, error.Message };
    }
}