// <copyright file="IRoleMenuPermissionRepository.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using Garuda.Domain.Common.Models;
using Garuda.Persistences.Abstract.Contracts;

namespace Garuda.Repository.Common.Repositories.Contracts;

/// <summary>
/// Represents a repository for managing role-menu permission entities.
/// </summary>
public interface IRoleMenuPermissionRepository : IRepository
{
    /// <summary>
    /// Executes a query to retrieve role-menu permission entities.
    /// </summary>
    /// <returns>An <see cref="IQueryable{RoleMenuPermission}"/> representing the result of the query.</returns>
    IQueryable<RoleMenuPermission> Query();

    /// <summary>
    /// Executes a query to retrieve a role-menu permission entity by its ID.
    /// </summary>
    /// <param name="id">The ID of the role-menu permission entity.</param>
    /// <returns>A <see cref="Task{RoleMenuPermission}"/> representing the asynchronous operation. The task result contains the role-menu permission entity.</returns>
    Task<RoleMenuPermission> Get(Guid id);

    /// <summary>
    /// Creates a new role-menu permission entity.
    /// </summary>
    /// <param name="model">The role-menu permission model to create.</param>
    /// <returns>The created role-menu permission.</returns>
    Task<RoleMenuPermission> Create(RoleMenuPermission model);

    /// <summary>
    /// Updates a role-menu permission entity.
    /// </summary>
    /// <param name="id">The ID of the role-menu permission entity to be updated.</param>
    /// <param name="model">The updated role-menu permission entity.</param>
    /// <returns>A <see cref="Task{RoleMenuPermission}"/> representing the asynchronous operation. The task result contains the deleted role-menu permission entity.</returns>
    Task<RoleMenuPermission> Update(Guid id, RoleMenuPermission model);

    /// <summary>
    /// Executes a query to delete a role-menu permission entity by its ID.
    /// </summary>
    /// <param name="id">The ID of the role-menu permission entity to be deleted.</param>
    /// <returns>A <see cref="Task{RoleMenuPermission}"/> representing the asynchronous operation. The task result contains the deleted role-menu permission entity.</returns>
    /// <remarks>
    /// If the role-menu permission entity with the specified ID does not exist, null will be returned.
    /// </remarks>
    Task<RoleMenuPermission> Delete(Guid id);

    /// <summary>
    /// Retrieves a list of role-menu permissions by the roles.
    /// </summary>
    /// <param name="menuItemId">The ID of the menu item.</param>
    /// <param name="roles">The list of role IDs.</param>
    /// <returns>The list of role-menu permissions.</returns>
    Task<List<RoleMenuPermission>> GetListByRoles(Guid menuItemId, List<Guid> roles);

    /// <summary>
    /// Retrieves a list of RoleMenuPermission entities based on a specific role ID.
    /// </summary>
    /// <param name="roleId">The ID of the role.</param>
    /// <returns>A list of RoleMenuPermission entities.</returns>
    Task<List<RoleMenuPermission>> GetListByRoleId(Guid roleId);
}