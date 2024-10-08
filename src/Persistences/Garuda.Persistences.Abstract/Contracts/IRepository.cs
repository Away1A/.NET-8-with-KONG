﻿// <copyright file="IRepository.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

namespace Garuda.Persistences.Abstract.Contracts;

/// <summary>
/// To register repository within data entity
/// </summary>
public interface IRepository
{
    /// <summary>
    ///     Storage Context on every Repository.
    /// </summary>
    /// <param name="storageContext"></param>
    void SetStorageContext(IStorageContext storageContext);
}