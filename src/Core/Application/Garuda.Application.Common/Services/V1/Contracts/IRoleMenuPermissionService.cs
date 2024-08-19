// <copyright file="IRoleMenuPermissionService.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using Garuda.Application.Common.Dto.Request;
using Garuda.Application.Common.Dto.Response;
using Garuda.Utilities.Dtos;
using Garuda.Utilities.Dtos.Response;
using Sieve.Models;

namespace Garuda.Application.Common.Services.V1.Contracts;

/// <summary>
/// Manage Security.
/// </summary>
public interface IRoleMenuPermissionService
{
    /// <summary>
    /// Get Details Menu Permission by Role Id.
    /// </summary>
    /// <param name="roleId"></param>
    /// <returns>A <see cref="ManageSecurityDetailsResponse"/> representing the asynchronous operation.</returns>
    Task<ManageSecurityDetailsResponse> GetByRoleId(Guid roleId);

    /// <summary>
    /// Get a paginated list of ManageSecurityListResponses.
    /// </summary>
    /// <param name="sieveModel">The SieveModel object used for filtering and sorting the list.</param>
    /// <returns>A PaginatedList of ManageSecurityListResponses representing the asynchronous operation.</returns>
    Task<PaginatedList<ManageSecurityListResponse>> GetList(SieveModel sieveModel);

    /// <summary>
    /// Posts a new ManageSecurityRequest.
    /// </summary>
    /// <param name="model">The ManageSecurityRequest object containing the data to be posted.</param>
    /// <returns>A <see cref="Task"/> representing the result of the operation.</returns>
    Task Create(PostManageSecurityRequest model);

    /// <summary>
    /// Update the ManageSecurity record with the specified ID.
    /// </summary>
    /// <param name="id">The ID of the ManageSecurity record to update.</param>
    /// <param name="model">The updated ManageSecurity data.</param>
    /// <returns>A <see cref="Task"/> representing the result of the operation.</returns>
    Task Update(Guid id, PutManageSecurityRequest model);

    /// <summary>
    /// Delete the ManageSecurity record with the specified ID.
    /// </summary>
    /// <param name="id">The ID of the ManageSecurity record to delete.</param>
    /// <returns>A <see cref="Task"/> representing the result of the operation.</returns>
    Task Delete(Guid id);
}