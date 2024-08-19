// <copyright file="ExtensionManager.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System.Collections.Concurrent;
using System.Reflection;

#pragma warning disable CS8604 // Possible null reference argument.
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning disable CS8603 // Possible null reference return.
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.

namespace Garuda.Utilities;

public static class ExtensionManager
{
    private static ConcurrentDictionary<Type, IEnumerable<Type>> types;

    public static IEnumerable<Assembly> Assemblies { get; private set; }

    public static void SetAssemblies(IEnumerable<Assembly> assemblies)
    {
        Assemblies = assemblies;
        types = new ConcurrentDictionary<Type, IEnumerable<Type>>();
    }

    public static Type GetImplementation<T>(bool useCaching = false)
    {
        return GetImplementation<T>(null, useCaching);
    }

    public static Type GetImplementation<T>(Func<Assembly, bool> predicate, bool useCaching = false)
    {
        return GetImplementations<T>(predicate, useCaching).FirstOrDefault();
    }

    public static IEnumerable<Type> GetImplementations<T>(bool useCaching = false)
    {
        return GetImplementations<T>(null, useCaching);
    }

    public static IEnumerable<Type> GetImplementations<T>(Func<Assembly, bool> predicate, bool useCaching = false)
    {
        var type = typeof(T);

        if (useCaching && types.ContainsKey(type))
        {
            return types[type];
        }

        var implementations = (from assembly in GetAssemblies(predicate)
                               from exportedType in assembly.GetExportedTypes()
                               where type.GetTypeInfo().IsAssignableFrom(exportedType) &&
                                     exportedType.GetTypeInfo().IsClass
                               select exportedType).ToList();

        if (useCaching)
        {
            types[type] = implementations;
        }

        return implementations;
    }

    public static T GetInstance<T>(bool useCaching = false)
    {
        return GetInstance<T>(null, useCaching, new object[] { });
    }

    public static T GetInstance<T>(bool useCaching = false, params object[] args)
    {
        return GetInstance<T>(null, useCaching, args);
    }

    public static T GetInstance<T>(Func<Assembly, bool> predicate, bool useCaching = false)
    {
        return GetInstances<T>(predicate, useCaching).FirstOrDefault();
    }

    public static T GetInstance<T>(Func<Assembly, bool> predicate, bool useCaching = false, params object[] args)
    {
        return GetInstances<T>(predicate, useCaching, args).FirstOrDefault();
    }

    public static IEnumerable<T> GetInstances<T>(bool useCaching = false)
    {
        return GetInstances<T>(null, useCaching, new object[] { });
    }

    public static IEnumerable<T> GetInstances<T>(bool useCaching = false, params object[] args)
    {
        return GetInstances<T>(null, useCaching, args);
    }

    public static IEnumerable<T> GetInstances<T>(Func<Assembly, bool> predicate, bool useCaching = false)
    {
        return GetInstances<T>(predicate, useCaching, new object[] { });
    }

    public static IEnumerable<T> GetInstances<T>(Func<Assembly, bool> predicate,
                                                 bool useCaching = false,
                                                 params object[] args)
    {
        var instances = new List<T>();

        foreach (var implementation in GetImplementations<T>(predicate, useCaching))
        {
            if (!implementation.GetTypeInfo().IsAbstract)
            {
                var instance = (T)Activator.CreateInstance(implementation, args);

                instances.Add(instance);
            }
        }

        return instances;
    }

    private static IEnumerable<Assembly> GetAssemblies(Func<Assembly, bool> predicate)
    {
        if (predicate == null)
        {
            return Assemblies;
        }

        return Assemblies.Where(predicate);
    }
}