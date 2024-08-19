// <copyright file="IUserSessionRepository.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using Garuda.Domain.Common.Models;
using Garuda.Persistences.Abstract.Contracts;

namespace Garuda.Repository.Common.Repositories.Contracts;

/// <summary>
/// Represents a repository for user session data.
/// </summary>
public interface IUserSessionRepository : IRepository
{
    /// <summary>
    /// Retrieves a queryable collection of UserSession objects.
    /// </summary>
    /// <returns>A queryable collection of UserSession objects.</returns>
    IQueryable<UserSession> Query();

    /// <summary>
    /// Retrieves the UserSession object with the specified id.
    /// </summary>
    /// <param name="id">The id of the UserSession.</param>
    /// <returns>The UserSession object with the specified id.</returns>
    Task<UserSession> Get(Guid id);

    /// <summary>
    /// Creates a new user session.
    /// </summary>
    /// <param name="model">The UserSession object to create.</param>
    /// <returns>The created UserSession object.</returns>
    Task<UserSession> Create(UserSession model);

    /// <summary>
    /// Deletes a user session with the specified id.
    /// </summary>
    /// <param name="id">The id of the user session to delete.</param>
    /// <returns>The deleted UserSession object.</returns>
    Task<UserSession> Delete(Guid id);

    /// <summary>
    /// Retrieves and validates a user session with the specified id.
    /// </summary>
    /// <param name="id">The id of the user session to retrieve and validate.</param>
    /// <returns>The user session object with the specified id if found; otherwise, null.</returns>
    Task<UserSession> GetAndValidateId(Guid id);

    /// <summary>
    /// Retrieves and validates a UserSession object by user ID.
    /// </summary>
    /// <param name="id">The unique identifier of the user.</param>
    /// <returns>The UserSession object matching the provided user ID.</returns>
    Task<UserSession> GetAndValidateByUserId(Guid id);

    /// <summary>
    /// Gets and validates a user session by refresh token.
    /// </summary>
    /// <param name="refreshToken">The refresh token.</param>
    /// <returns>The user session.</returns>
    Task<UserSession> GetAndValidateRefreshToken(string refreshToken);

    /// <summary>
    /// Revokes the token for a user session.
    /// </summary>
    /// <param name="token">The token to revoke.</param>
    /// <returns>The revoked UserSession object.</returns>
    Task<UserSession> RevokeToken(string token);
}