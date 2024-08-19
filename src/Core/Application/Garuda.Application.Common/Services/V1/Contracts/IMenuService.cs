// <copyright file="IMenuService.cs" company="CV Garuda Infinity Kreasindo">
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
///     Menu contract services.
/// </summary>
public interface IMenuService
{
    /// <summary>
    /// Retrieves a menu item by its ID.
    /// </summary>
    /// <param name="id">The ID of the menu item to retrieve.</param>
    /// <returns>A <see cref="Task{MenuResponse}"/> representing the asynchronous operation. The task result contains the menu item.</returns>
    Task<MenuResponse> Get(Guid id);

    /// <summary>
    /// Retrieves the menu items.
    /// </summary>
    /// <returns>A list of menu items.</returns>
    Task<List<MenuResponse>> GetList();

    /// <summary>
    /// Retrieves the menu items.
    /// </summary>
    /// <param name="sieveModel"></param>
    /// <returns>A <see>
    ///         <cref>Task{PaginatedList{MenuResponse}}</cref>
    ///     </see>
    ///     representing the asynchronous operation.</returns>
    Task<PaginatedList<MenuResponse>> GetListByFilter(SieveModel sieveModel);

    /// <summary>
    ///     Get Menu by User Id.
    /// </summary>
    /// <param name="session"></param>
    /// <returns>A <see cref="MenuResponse" /> representing the asynchronous operation.</returns>
    Task<List<MenuResponse>> GetMenuBySession(SessionDto session);

    /// <summary>
    /// Creates a new menu item.
    /// </summary>
    /// <param name="model">The menu item to create.</param>
    /// <returns>A <see cref="Task"/> representing the result of the operation.</returns>
    Task Create(MenuRequest model);

    /// <summary>
    /// Updates an existing menu item.
    /// </summary>
    /// <param name="id">The ID of the menu item to update.</param>
    /// <param name="model">The updated menu item data.</param>
    /// <returns>A <see cref="Task"/> representing the result of the operation.</returns>
    Task Update(Guid id, MenuRequest model);

    /// <summary>
    /// Delete a menu item.
    /// </summary>
    /// <param name="id">The ID of the menu item .</param>
    /// <returns>A <see cref="Task"/> representing the result of the operation.</returns>
    Task Delete(Guid id);
}