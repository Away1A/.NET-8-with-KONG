// <copyright file="ReflectionHelper.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System.Reflection;

namespace Garuda.Utilities.Helpers;

public class ReflectionHelper
{
    /// <summary>
    ///     Checks whether <paramref name="givenType" /> implements/inherits <paramref name="genericType" />.
    /// </summary>
    /// <param name="givenType">Type to check</param>
    /// <param name="genericType">Generic type</param>
    public static bool IsAssignableToGenericType(Type givenType, Type genericType)
    {
        var givenTypeInfo = givenType.GetTypeInfo();

        if (givenTypeInfo.IsGenericType && givenType.GetGenericTypeDefinition() == genericType)
        {
            return true;
        }

        if (givenTypeInfo.GetInterfaces()
                         .Any(interfaceType => interfaceType.GetTypeInfo().IsGenericType &&
                                               interfaceType.GetGenericTypeDefinition() == genericType))
        {
            return true;
        }

        return givenTypeInfo.BaseType != null && IsAssignableToGenericType(givenTypeInfo.BaseType, genericType);
    }
}