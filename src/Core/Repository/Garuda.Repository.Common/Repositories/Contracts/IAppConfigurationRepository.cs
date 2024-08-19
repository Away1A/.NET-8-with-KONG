// <copyright file="IAppConfigurationRepository.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using Garuda.Domain.Common.Models;
using Garuda.Persistences.Abstract.Contracts;

namespace Garuda.Repository.Common.Repositories.Contracts;

/// <summary>
/// Represents the interface for the AppConfiguration repository.
/// </summary>
public interface IAppConfigurationRepository : IRepository
{
    /// <summary>
    /// Retrieves the query for the AppConfiguration repository.
    /// </summary>
    /// <returns>An IQueryable of AppConfiguration objects.</returns>
    IQueryable<AppConfiguration> Query();

    /// <summary>
    /// Retrieves the AppConfiguration with the specified id.
    /// </summary>
    /// <param name="id">The unique identifier of the AppConfiguration.</param>
    /// <returns>A Task representing the asynchronous operation. The result contains the AppConfiguration with the specified id.</returns>
    Task<AppConfiguration> Get(Guid id);

    /// <summary>
    /// Retrieves the AppConfiguration with the specified key.
    /// </summary>
    /// <param name="key">The key of the AppConfiguration.</param>
    /// <returns>A Task representing the asynchronous operation. The result contains the AppConfiguration with the specified key.</returns>
    Task<AppConfiguration> Get(string key);

    /// <summary>
    /// Updates the AppConfiguration model with the given id.
    /// </summary>
    /// <param name="id">The id of the AppConfiguration to update.</param>
    /// <param name="model">The updated AppConfiguration model.</param>
    /// <returns>A Task representing the asynchronous operation. The updated AppConfiguration model.</returns>
    Task<AppConfiguration> Update(Guid id, AppConfiguration model);
}