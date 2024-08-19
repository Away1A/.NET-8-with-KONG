// <copyright file="MenuController.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using Asp.Versioning;
using Garuda.Application.Common.Dto.Request;
using Garuda.Application.Common.Dto.Response;
using Garuda.Application.Common.Services.V1.Contracts;
using Garuda.Utilities.Constants;
using Garuda.Utilities.Dtos;
using Garuda.Utilities.Dtos.Response;
using Garuda.Utilities.Exceptions;
using Garuda.Utilities.Helpers;
using Garuda.Utilities.Middleware;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;

namespace Garuda.Presentation.Common.Controllers.V1;

[Authorize]
[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/menus")]
[Produces("application/json")]
[Tags("Menu")]
public class MenuController : Controller
{
    private readonly IMenuService _menuService;

    /// <summary>
    ///     Initializes a new instance of the <see cref="MenuController" /> class.
    /// </summary>
    /// <param name="menuService"></param>
    public MenuController(IMenuService menuService)
    {
        _menuService = menuService;
    }

    /// <summary>
    /// Get List Menu by filter.
    /// </summary>
    /// <param name="sieveModel">The <see cref="SieveModel"/> used for filtering the menu list.</param>
    /// <returns>A list of <see cref="MenuResponse"/>.</returns>
    [HttpGet]
    [ProducesResponseType(HttpStatusCodes.Success, Type = typeof(PaginatedList<MenuResponse>))]
    [ProducesResponseType(HttpStatusCodes.Unauthorized, Type = typeof(MessageDto))]
    public async Task<IActionResult> GetByFilter([FromQuery] SieveModel sieveModel)
    {
        return Ok(await _menuService.GetListByFilter(sieveModel));
    }

    /// <summary>
    /// Get Menu by ID.
    /// </summary>
    /// <param name="id">The ID of the menu.</param>
    /// <returns>An <see cref="IActionResult" /> representing the result of the get operation.</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(HttpStatusCodes.Success, Type = typeof(MenuResponse))]
    [ProducesResponseType(HttpStatusCodes.Unauthorized, Type = typeof(MessageDto))]
    public async Task<IActionResult> Get(Guid id)
    {
        return Ok(await _menuService.Get(id));
    }

    /// <summary>
    /// Get List Menu.
    /// </summary>
    /// <returns>
    /// A <see cref="List{MenuResponse}" /> representing the asynchronous operation.
    /// </returns>
    [HttpGet("list")]
    [ProducesResponseType(HttpStatusCodes.Success, Type = typeof(List<MenuResponse>))]
    [ProducesResponseType(HttpStatusCodes.Unauthorized, Type = typeof(MessageDto))]
    public async Task<IActionResult> GetList()
    {
        return Ok(await _menuService.GetList());
    }

    /// <summary>
    /// Posts a new menu.
    /// </summary>
    /// <param name="model">The menu request object containing the information of the menu.</param>
    /// <returns>A <see cref="Task{IActionResult}"/> representing the asynchronous operation.</returns>
    [HttpPost]
    [ProducesResponseType(HttpStatusCodes.Success, Type = typeof(MessageDto))]
    [ProducesResponseType(HttpStatusCodes.NotFound, Type = typeof(MessageDto))]
    [ProducesResponseType(HttpStatusCodes.Unauthorized, Type = typeof(MessageDto))]
    [ProducesResponseType(HttpStatusCodes.BadRequest, Type = typeof(MessageDto))]
    public async Task<IActionResult> Post([FromBody] MenuRequest model)
    {
        if (!ModelState.IsValid)
        {
            throw new HttpResponseLibraryException(HttpStatusCodes.ErrorTransaction,
                                                   HttpStatusTitles.UnprocessableEntity,
                                                   string.Empty,
                                                   ModelState.ExtractToString());
        }

        await _menuService.Create(model);
        return NoContent();
    }

    /// <summary>
    /// Updates a menu item by its ID.
    /// </summary>
    /// <param name="id">The ID of the menu item to update.</param>
    /// <param name="model">The updated menu information.</param>
    /// <returns>A message indicating the status of the operation.</returns>
    [HttpPut("{id}")]
    [ProducesResponseType(HttpStatusCodes.Success, Type = typeof(MessageDto))]
    [ProducesResponseType(HttpStatusCodes.NotFound, Type = typeof(MessageDto))]
    [ProducesResponseType(HttpStatusCodes.Unauthorized, Type = typeof(MessageDto))]
    [ProducesResponseType(HttpStatusCodes.BadRequest, Type = typeof(MessageDto))]
    public async Task<IActionResult> Put(Guid id, [FromBody] MenuRequest model)
    {
        if (!ModelState.IsValid)
        {
            throw new HttpResponseLibraryException(HttpStatusCodes.ErrorTransaction,
                                                   "UNPROCESSABLE ENTITY",
                                                   string.Empty,
                                                   ModelState.ExtractToString());
        }

        await _menuService.Update(id, model);
        return NoContent();
    }

    /// <summary>
    /// Delete a menu by its ID.
    /// </summary>
    /// <param name="id">The ID of the menu.</param>
    /// <returns>An asynchronous operation that returns a <see cref="MessageDto"/> indicating the status change result.</returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(HttpStatusCodes.Success, Type = typeof(MessageDto))]
    [ProducesResponseType(HttpStatusCodes.NotFound, Type = typeof(MessageDto))]
    [ProducesResponseType(HttpStatusCodes.Unauthorized, Type = typeof(MessageDto))]
    [ProducesResponseType(HttpStatusCodes.BadRequest, Type = typeof(MessageDto))]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _menuService.Delete(id);
        return NoContent();
    }
}