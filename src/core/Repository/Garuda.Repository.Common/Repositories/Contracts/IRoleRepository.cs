// <copyright file="IRoleRepository.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using Garuda.Domain.Common.Models;
using Garuda.Persistences.Abstract.Contracts;

namespace Garuda.Repository.Common.Repositories.Contracts;

/// <summary>
/// Represents a repository for managing roles.
/// </summary>
public interface IRoleRepository : IRepository
{
    /// <summary>
    /// Retrieves all roles from the role repository.
    /// </summary>
    /// <returns>An IQueryable of the Role entity.</returns>
    IQueryable<Role> Query();

    /// <summary>
    /// Gets a role by its ID.
    /// </summary>
    /// <param name="id">The ID of the role.</param>
    /// <returns>The role with the specified ID.</returns>
    Task<Role> Get(Guid id);

    /// <summary>
    /// Creates a new role.
    /// </summary>
    /// <param name="model">The role to create.</param>
    /// <returns>The created role.</returns>
    Task<Role> Create(Role model);

    /// <summary>
    /// Updates a role in the role repository.
    /// </summary>
    /// <param name="id">The ID of the role to update.</param>
    /// <param name="model">The updated Role object.</param>
    /// <returns>The updated Role object.</returns>
    Task<Role> Update(Guid id, Role model);

    /// <summary>
    /// Deletes a role from the role repository.
    /// </summary>
    /// <param name="id">The ID of the role to be deleted.</param>
    /// <returns>The deleted role.</returns>
    Task<Role> Delete(Guid id);

    /// <summary>
    /// Retrieves a role from the repository and validates if there is a duplicate role with the same name.
    /// </summary>
    /// <param name="id">The ID of the role to retrieve. Null if creating a new role.</param>
    /// <param name="name">The name of the role.</param>
    /// <param name="isActive">Indicates whether the role is active or not.</param>
    /// <returns>
    /// A <see cref="Task"/> representing the asynchronous operation. The task result contains a <see cref="Role"/> object with the retrieved role or a new role if creating a new role.
    /// The task result is never null.
    /// </returns>
    Task<Role> GetAndValidateDuplicate(Guid? id, string name, bool isActive);
}