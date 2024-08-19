// <copyright file="IUserRoleRepository.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using Garuda.Domain.Common.Models;
using Garuda.Persistences.Abstract.Contracts;

namespace Garuda.Repository.Common.Repositories.Contracts;

/// <summary>
/// Represents an interface for working with user role repository
/// </summary>
public interface IUserRoleRepository : IRepository
{
    /// <summary>
    /// Executes a query to retrieve all user roles.
    /// </summary>
    /// <returns>The query result as an IQueryable of UserRole objects.</returns>
    IQueryable<UserRole> Query();

    /// <summary>
    /// Executes a query to retrieve a user role by its ID.
    /// </summary>
    /// <param name="id">The ID of the user role.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the user role as a UserRole object.</returns>
    Task<UserRole> Get(Guid id);

    /// <summary>
    /// Creates a new user role.
    /// </summary>
    /// <param name="model">The user role object to be created.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the created user role as a UserRole object.</returns>
    Task<UserRole> Create(UserRole model);

    /// <summary>
    /// Updates a user role.
    /// </summary>
    /// <param name="id">The ID of the user role to update.</param>
    /// <param name="model">The updated user role object.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the updated user role as a UserRole object.</returns>
    Task<UserRole> Update(Guid id, UserRole model);

    /// <summary>
    /// Deletes a user role by its ID.
    /// </summary>
    /// <param name="id">The ID of the user role to be deleted.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the deleted user role as a UserRole object.</returns>
    Task<UserRole> Delete(Guid id);

    /// <summary>
    /// Deletes a user role by the user ID and role ID.
    /// </summary>
    /// <param name="userId">The ID of the user.</param>
    /// <param name="roleId">The ID of the role.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task DeleteByUserIdAndRoleId(Guid userId, Guid roleId);

    /// <summary>
    /// Retrieves and validates a user role by its ID.
    /// </summary>
    /// <param name="id">The ID of the user role.</param>
    /// <returns>The user role as a UserRole object if it exists, otherwise null.</returns>
    Task<UserRole> GetAndValidateById(Guid id);
}