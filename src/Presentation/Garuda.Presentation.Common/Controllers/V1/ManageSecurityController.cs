// <copyright file="ManageSecurityController.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using Asp.Versioning;
using Garuda.Application.Common.Dto.Request;
using Garuda.Application.Common.Dto.Response;
using Garuda.Application.Common.Services.V1.Contracts;
using Garuda.Utilities.Constants;
using Garuda.Utilities.Dtos;
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
[Route("api/v{version:apiVersion}/manage-securities")]
[Produces("application/json")]
[Tags("Manage Security / Role Menu Permission")]
public class ManageSecurityController : Controller
{
    private readonly IRoleMenuPermissionService _roleMenuPermissionService;

    /// <summary>
    /// Initializes a new instance of the <see cref="ManageSecurityController"/> class.
    /// </summary>
    /// <param name="roleMenuPermissionService"></param>
    public ManageSecurityController(IRoleMenuPermissionService roleMenuPermissionService)
    {
        _roleMenuPermissionService = roleMenuPermissionService;
    }

    /// <summary>
    ///     Get list of role menu permission
    /// </summary>
    /// <param name="model"></param>
    /// <returns>A <see cref="ManageSecurityListResponse" /> representing the asynchronous operation.</returns>
    [HttpGet]
    [ProducesResponseType(HttpStatusCodes.Success, Type = typeof(List<ManageSecurityListResponse>))]
    [ProducesResponseType(HttpStatusCodes.NotFound, Type = typeof(MessageDto))]
    [ProducesResponseType(HttpStatusCodes.BadRequest)]
    public async Task<IActionResult> GetList([FromQuery] SieveModel model)
    {
        return Ok(await _roleMenuPermissionService.GetList(model));
    }

    /// <summary>
    ///     Get details of role menu permission
    /// </summary>
    /// <param name="roleId"></param>
    /// <returns>A <see cref="ManageSecurityListResponse" /> representing the asynchronous operation.</returns>
    [HttpGet]
    [Route("{roleId}")]
    [ProducesResponseType(HttpStatusCodes.Success, Type = typeof(List<ManageSecurityListResponse>))]
    [ProducesResponseType(HttpStatusCodes.NotFound, Type = typeof(MessageDto))]
    [ProducesResponseType(HttpStatusCodes.BadRequest)]
    public async Task<IActionResult> GetByRoleId(Guid roleId)
    {
        return Ok(await _roleMenuPermissionService.GetByRoleId(roleId));
    }

    /// <summary>
    ///     Create new role menu permission
    /// </summary>
    /// <param name="model"></param>
    /// <returns>A <see cref="ManageSecurityListResponse" /> representing the asynchronous operation.</returns>
    [HttpPost]
    [ProducesResponseType(HttpStatusCodes.Success, Type = typeof(MessageDto))]
    [ProducesResponseType(HttpStatusCodes.NotFound, Type = typeof(MessageDto))]
    [ProducesResponseType(HttpStatusCodes.BadRequest)]
    public async Task<IActionResult> Post([FromBody] PostManageSecurityRequest model)
    {
        if (!ModelState.IsValid)
        {
            throw new HttpResponseLibraryException(HttpStatusCodes.ErrorTransaction,
                                                   HttpStatusTitles.UnprocessableEntity,
                                                   string.Empty,
                                                   ModelState.ExtractToString());
        }

        await _roleMenuPermissionService.Create(model);
        return NoContent();
    }

    /// <summary>
    ///     Create new role menu permission
    /// </summary>
    /// <param name="id"></param>
    /// <param name="model"></param>
    /// <returns>A <see cref="ManageSecurityListResponse" /> representing the asynchronous operation.</returns>
    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType(HttpStatusCodes.Success, Type = typeof(MessageDto))]
    [ProducesResponseType(HttpStatusCodes.NotFound, Type = typeof(MessageDto))]
    [ProducesResponseType(HttpStatusCodes.BadRequest)]
    public async Task<IActionResult> Put(Guid id, [FromBody] PutManageSecurityRequest model)
    {
        if (!ModelState.IsValid)
        {
            throw new HttpResponseLibraryException(HttpStatusCodes.ErrorTransaction,
                                                   HttpStatusTitles.UnprocessableEntity,
                                                   string.Empty,
                                                   ModelState.ExtractToString());
        }

        await _roleMenuPermissionService.Update(id, model);
        return NoContent();
    }
}