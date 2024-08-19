// <copyright file="IRoleService.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using Garuda.Application.Common.Dto.Request;
using Garuda.Application.Common.Dto.Response;
using Garuda.Utilities.Dtos;
using Garuda.Utilities.Dtos.Response;
using Sieve.Models;

namespace Garuda.Application.Common.Services.V1.Contracts;

/// <summary>
///     Group services contract.
/// </summary>
public interface IRoleService
{
    /// <summary>
    /// Retrieves a group based on its ID.
    /// </summary>
    /// <param name="id">The ID of the group to retrieve.</param>
    /// <returns>A <see cref="Task{GroupResponse}"/> representing the asynchronous operation.</returns>
    Task<RoleResponse> Get(Guid id);

    /// <summary>
    /// Retrieves a list of groups based on the provided sieve model.
    /// </summary>
    /// <param name="sieveModel">The sieve model used for filtering, sorting, and paging the groups.</param>
    /// <returns>A list of <see cref="RoleResponse"/>.</returns>
    Task<PaginatedList<RoleResponse>> GetList(SieveModel sieveModel);

    /// <summary>
    /// Creates a new group.
    /// </summary>
    /// <param name="model">The group model to create.</param>
    /// <returns>A <see cref="Task"/> representing the result of the operation.</returns>
    Task Create(RoleRequest model);

    /// <summary>
    /// Updates an existing group with the specified ID.
    /// </summary>
    /// <param name="id">The ID of the group to update.</param>
    /// <param name="model">The updated group model.</param>
    /// <returns>A <see cref="Task"/> representing the result of the operation.</returns>
    Task Update(Guid id, RoleRequest model);

    /// <summary>
    /// Changes the status of a group with the specified ID.
    /// </summary>
    /// <param name="id">The ID of the group to change the status.</param>
    /// <returns>A <see cref="Task"/> representing the result of the operation.</returns>
    Task Delete(Guid id);
}