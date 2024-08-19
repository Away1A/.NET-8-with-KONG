// <copyright file="IAppConfigurationService.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using Garuda.Application.Common.Dto.Request;
using Garuda.Application.Common.Dto.Response;
using Garuda.Utilities.Dtos;
using Garuda.Utilities.Dtos.Response;
using Sieve.Models;

namespace Garuda.Application.Common.Services.V1.Contracts;

/// <summary>
/// Represents an interface for retrieving and modifying application configuration data.
/// </summary>
public interface IAppConfigurationService
{
    /// <summary>
    /// Retrieves an application configuration by its ID.
    /// </summary>
    /// <param name="id">The ID of the configuration.</param>
    /// <returns>The application configuration response.</returns>
    Task<AppConfigurationResponse> Get(Guid id);

    /// <summary>
    /// Retrieves an application configuration by its key.
    /// </summary>
    /// <param name="key">The value of the configuration.</param>
    /// <returns>The application configuration response.</returns>
    Task<AppConfigurationResponse> Get(string key);

    /// <summary>
    /// Retrieves a paginated list of application configurations based on the given SieveModel.
    /// </summary>
    /// <param name="sieveModel">The SieveModel for filtering, sorting, and pagination.</param>
    /// <returns>A PaginatedList<AppConfigurationResponse/> object containing a page of application configurations.</returns>
    Task<PaginatedList<AppConfigurationResponse>> GetList(SieveModel sieveModel);

    /// <summary>
    /// Updates an application configuration by its ID.
    /// </summary>
    /// <param name="id">The ID of the configuration to update.</param>
    /// <param name="model">The <see cref="AppConfigurationRequest"/> object containing the updated data.</param>
    /// <returns>A <see cref="Task"/> representing the result of the operation.</returns>
    Task Update(Guid id, AppConfigurationRequest model);
}