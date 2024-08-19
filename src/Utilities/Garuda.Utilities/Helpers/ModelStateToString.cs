// <copyright file="ModelStateToString.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Garuda.Utilities.Helpers;

// To Extract Model State from POST to string
public static class ModelStateToString
{
    /// <summary>
    /// Extract ModelState to string to check error based on Annotation on Dto.
    /// </summary>
    /// <param name="data"></param>
    /// <returns>extracted string</returns>
    public static string ExtractToString(this ModelStateDictionary data)
    {
        var resultString = string.Empty;
        var dataErrors = data.Where(x => x.Value != null && x.Value.Errors.Count > 0);

        return dataErrors.Aggregate(resultString,
                                    (current, error) =>
                                        current + $"{error.Key} : {error.Value?.Errors[0].ErrorMessage} \n");
    }
}