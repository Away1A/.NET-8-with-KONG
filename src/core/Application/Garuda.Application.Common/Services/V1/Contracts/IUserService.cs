// <copyright file="IUserService.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using Garuda.Application.Common.Dto;
using Garuda.Application.Common.Dto.Request;
using Garuda.Application.Common.Dto.Response;
using Garuda.Utilities.Dtos;
using Garuda.Utilities.Dtos.Response;
using Sieve.Models;

namespace Garuda.Application.Common.Services.V1.Contracts;

/// <summary>
///     User Service Contracts.
/// </summary>
public interface IUserService
{
    /// <summary>
    ///     Get User By Id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns>A <see cref="UserResponse"/> representing the asynchronous operation.</returns>
    Task<UserResponse> GetById(Guid id);

    /// <summary>
    ///     Get user profile by user id.
    /// </summary>
    /// <param name="session"></param>
    /// <returns>A <see cref="UserProfileResponse" /> representing the asynchronous operation.</returns>
    Task<UserProfileResponse> GetUserProfile(SessionDto session);

    /// <summary>
    ///     Get paged list of active users.
    /// </summary>
    /// <param name="sieveModel"></param>
    /// <returns>A <see>
    ///         <cref>PaginatedResponses{UserResponse}</cref>
    ///     </see>
    ///     representing the result of the asynchronous operation.</returns>
    Task<PaginatedList<UserResponse>> GetList(SieveModel sieveModel);

    /// <summary>
    ///     Create new user.
    /// </summary>
    /// <param name="model"></param>
    /// <returns>A <see cref="Task"/> representing the result of the operation.</returns>
    Task Create(PostUserRequest model);

    /// <summary>
    ///     Edit user by id.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="model"></param>
    /// <returns>A <see cref="Task"/> representing the result of the operation.</returns>
    Task Update(Guid id, PutUserRequest model);

    /// <summary>
    ///     Delete user by Id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns>A <see cref="Task"/> representing the result of the operation.</returns>
    Task Delete(Guid id);
}