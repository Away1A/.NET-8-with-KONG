// <copyright file="RoleController.cs" company="CV Garuda Infinity Kreasindo">
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
[Route("api/v{version:apiVersion}/roles")]
[Produces("application/json")]
[Tags("Roles")]
public class RoleController : Controller
{
    private readonly IRoleService _roleServices;

    /// <summary>
    /// Initializes a new instance of the <see cref="RoleController"/> class.
    /// </summary>
    /// <param name="roleService"></param>
    public RoleController(IRoleService roleService)
    {
        _roleServices = roleService;
    }

    /// <summary>
    /// Get Role Data.
    /// </summary>
    /// <param name="id">The id of the role to retrieve.</param>
    /// <returns>A <see cref="List{RoleMasterResponses}" /> representing the asynchronous operation.</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(HttpStatusCodes.Success, Type = typeof(RoleResponse))]
    [ProducesResponseType(HttpStatusCodes.Unauthorized, Type = typeof(MessageDto))]
    public async Task<IActionResult> Get(Guid id)
    {
        return Ok(await _roleServices.Get(id));
    }

    /// <summary>
    /// Get List Role Data.
    /// </summary>
    /// <param name="sieveModel">The SieveModel object for pagination and filtering.</param>
    /// <returns>An IActionResult representing the asynchronous operation.</returns>
    [HttpGet]
    [ProducesResponseType(HttpStatusCodes.Success, Type = typeof(PaginatedList<RoleResponse>))]
    [ProducesResponseType(HttpStatusCodes.Unauthorized, Type = typeof(MessageDto))]
    public async Task<IActionResult> Get([FromQuery] SieveModel sieveModel)
    {
        return Ok(await _roleServices.GetList(sieveModel));
    }

    /// <summary>
    /// Get List Role Data.
    /// </summary>
    /// <returns>A <see cref="Task{IActionResult}"/> representing the asynchronous operation.</returns>
    [HttpGet("list")]
    [ProducesResponseType(HttpStatusCodes.Success, Type = typeof(List<RoleResponse>))]
    [ProducesResponseType(HttpStatusCodes.Unauthorized, Type = typeof(MessageDto))]
    public async Task<IActionResult> GetData()
    {
        var data = await _roleServices.Get(Guid.Empty);
        return Ok(data);
    }

    /// <summary>
    /// Creates a new role.
    /// </summary>
    /// <param name="model">The RoleRequest object that contains the role details.</param>
    /// <returns>An IActionResult object representing the HTTP response.</returns>
    /// <remarks>
    /// This method will create a new role using the provided role details in the RoleRequest object.
    /// It will validate the model and return an HTTP response indicating the success or failure of the operation.
    /// </remarks>
    [HttpPost]
    [ProducesResponseType(HttpStatusCodes.Success, Type = typeof(MessageDto))]
    [ProducesResponseType(HttpStatusCodes.Unauthorized, Type = typeof(MessageDto))]
    [ProducesResponseType(HttpStatusCodes.BadRequest, Type = typeof(MessageDto))]
    public async Task<IActionResult> Post([FromBody] RoleRequest model)
    {
        if (!ModelState.IsValid)
        {
            throw new HttpResponseLibraryException(HttpStatusCodes.ErrorTransaction,
                                                   HttpStatusTitles.UnprocessableEntity,
                                                   string.Empty,
                                                   ModelState.ExtractToString());
        }

        await _roleServices.Create(model);
        return NoContent();
    }

    /// <summary>
    /// Updates a role with the specified ID.
    /// </summary>
    /// <param name="id">The ID of the role to update.</param>
    /// <param name="model">The role details to update.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    /// <remarks>
    /// This method requires the caller to be authenticated.
    /// If the model is not valid, a <see cref="HttpResponseLibraryException"/> will be thrown.
    /// </remarks>
    [HttpPut("{id}")]
    [ProducesResponseType(HttpStatusCodes.Success, Type = typeof(MessageDto))]
    [ProducesResponseType(HttpStatusCodes.Unauthorized, Type = typeof(MessageDto))]
    [ProducesResponseType(HttpStatusCodes.BadRequest, Type = typeof(MessageDto))]
    [ProducesResponseType(HttpStatusCodes.NotFound, Type = typeof(MessageDto))]
    public async Task<IActionResult> Put(Guid id, [FromBody] RoleRequest model)
    {
        if (!ModelState.IsValid)
        {
            throw new HttpResponseLibraryException(HttpStatusCodes.ErrorTransaction,
                                                   HttpStatusTitles.UnprocessableEntity,
                                                   string.Empty,
                                                   ModelState.ExtractToString());
        }

        await _roleServices.Update(id, model);
        return NoContent();
    }

    /// <summary>
    /// Delete of a Role.
    /// </summary>
    /// <param name="id">The ID of the role to change the status for.</param>
    /// <returns>Returns a MessageDto object representing the result of the status change operation.</returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(HttpStatusCodes.Success, Type = typeof(MessageDto))]
    [ProducesResponseType(HttpStatusCodes.Unauthorized, Type = typeof(MessageDto))]
    [ProducesResponseType(HttpStatusCodes.BadRequest, Type = typeof(MessageDto))]
    [ProducesResponseType(HttpStatusCodes.NotFound, Type = typeof(MessageDto))]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _roleServices.Delete(id);
        return NoContent();
    }
}