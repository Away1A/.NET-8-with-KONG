// <copyright file="IEntityRegister.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;

namespace Garuda.Persistences.Framework;

/// <summary>
/// IEntity Register contract interface
/// </summary>
public interface IEntityRegister
{
    /// <summary>
    /// Register entity to build a model to database
    /// </summary>
    /// <param name="modelbuilder"></param>
    void RegisterEntities(ModelBuilder modelbuilder);
}