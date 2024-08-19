// <copyright file="CompositeSieveCustomSortBuilder.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System.Reflection;
using System.Reflection.Emit;
using Sieve.Services;

namespace Garuda.Utilities.Helpers;

public class CompositeSieveCustomSortBuilder
{
    private static Type? _type;

    public static Type Build(params Type[] types)
    {
        if (_type != null)
        {
            return _type;
        }

        var assemblyName = new AssemblyName("DynamicAssembly");
        var assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);
        var moduleBuilder = assemblyBuilder.DefineDynamicModule("DynamicModule");
        var typeBuilder = moduleBuilder.DefineType("DynamicCompositeSieveCustomSorts", TypeAttributes.Public);
        typeBuilder.AddInterfaceImplementation(typeof(ISieveCustomSortMethods));

        foreach (var t in types)
        {
            if (t.GetInterface(nameof(ISieveCustomSortMethods)) == null)
            {
                continue;
            }

            foreach (var method in t.GetMethods(BindingFlags.Instance | BindingFlags.Public))
            {
                var parameters = method.GetParameters();
                if (parameters.Length != 3 ||
                    parameters[0].ParameterType != method.ReturnType ||
                    parameters[1].ParameterType != typeof(bool) ||
                    parameters[2].ParameterType != typeof(bool))
                {
                    continue;
                }

                MethodBuilder methodBuilder = typeBuilder.DefineMethod(method.Name,
                                                                       method.Attributes,
                                                                       method.ReturnType,
                                                                       method.GetParameters()
                                                                             .Select(p => p.ParameterType)
                                                                             .ToArray());
                ILGenerator il = methodBuilder.GetILGenerator();
                il.Emit(OpCodes.Ldarg_0);
                il.Emit(OpCodes.Ldarg_1);
                il.Emit(OpCodes.Ldarg_2);
                il.Emit(OpCodes.Ldarg_3);
                il.Emit(OpCodes.Callvirt, method);
                il.Emit(OpCodes.Ret);
            }
        }

        _type = typeBuilder.CreateType();
        if (_type == null)
        {
            throw new Exception("DynamicCompositeSieveCustomSort cannot be created");
        }

        return _type;
    }
}