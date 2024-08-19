// <copyright file="IMenuRepository.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using Garuda.Domain.Common.Models;
using Garuda.Persistences.Abstract.Contracts;

namespace Garuda.Repository.Common.Repositories.Contracts;

/// <summary>
/// Represents the interface for accessing and manipulating menu data.
/// </summary>
public interface IMenuRepository : IRepository
{
    /// <summary>
    /// Executes a query to retrieve all menu items.
    /// </summary>
    /// <returns>An IQueryable of Menu.</returns>
    IQueryable<Menu> Query();

    /// <summary>
    /// Retrieves a menu item by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the menu.</param>
    /// <returns>A Task representing the asynchronous operation. The result is the menu item with the specified identifier.</returns>
    Task<Menu> Get(Guid id);

    /// <summary>
    /// Retrieves the parent menus.
    /// </summary>
    /// <returns>A list of parent menus.</returns>
    Task<List<Menu>> GetParent();

    /// <summary>
    /// Gets the child menus based on the parent menu ID.
    /// </summary>
    /// <param name="parentId">The ID of the parent menu.</param>
    /// <returns>The list of child menus.</returns>
    Task<List<Menu>> GetChildByParentId(Guid parentId);

    /// <summary>
    /// Retrieves the menus for a user session.
    /// </summary>
    /// <param name="userId">The ID of the user.</param>
    /// <returns>A list of menus for the user session.</returns>
    Task<List<Menu>> GetByUserSession(Guid userId);

    /// <summary>
    /// Creates a new menu item.
    /// </summary>
    /// <param name="model">The menu item to create.</param>
    /// <returns>A Task representing the asynchronous operation. The result is the created menu item.</returns>
    Task<Menu> Create(Menu model);

    /// <summary>
    /// Updates a menu item in the database.
    /// </summary>
    /// <param name="id">The ID of the menu item to update.</param>
    /// <param name="model">The updated menu item.</param>
    /// <returns>A Task representing the asynchronous operation. The updated menu item.</returns>
    Task<Menu> Update(Guid id, Menu model);

    /// <summary>
    /// Deletes a menu item by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the menu item to delete.</param>
    /// <returns>A Task representing the asynchronous operation. The result is the deleted menu item.</returns>
    Task<Menu> Delete(Guid id);
}