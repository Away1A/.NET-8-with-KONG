// <copyright file="IAssemblyProvider.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System.Reflection;

namespace Garuda.Extension.Contracts;

/// <summary>
/// Assembly Provider contract
/// </summary>
public interface IAssemblyProvider
{
    /// <summary>
    /// Populating assembly
    /// </summary>
    /// <param name="path"></param>
    /// <param name="includingSubpaths"></param>
    /// <returns>IEnumerable<Assembly />
    /// </returns>
    IEnumerable<Assembly> GetAssemblies(string path, bool includingSubpaths);
}