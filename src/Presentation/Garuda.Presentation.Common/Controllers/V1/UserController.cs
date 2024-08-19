// <copyright file="UserController.cs" company="CV Garuda Infinity Kreasindo">
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
[Route("api/v{version:apiVersion}/users")]
[Produces("application/json")]
[Tags("User")]
public class UserController : Controller
{
    private readonly IUserService _userService;
    private readonly IAuthService _authService;
    private readonly IMenuService _menuService;

    /// <summary>
    ///     Initializes a new instance of the <see cref="UserController" /> class.
    /// </summary>
    /// <param name="userService"></param>
    /// <param name="authService"></param>
    /// <param name="menuService"></param>
    public UserController(IUserService userService, IAuthService authService, IMenuService menuService)
    {
        _userService = userService;
        _authService = authService;
        _menuService = menuService;
    }

    /// <summary>
    ///     Get List Users.
    /// </summary>
    /// <returns>A <see cref="UserResponse" /> representing the asynchronous operation.</returns>
    [HttpGet]
    [ProducesResponseType(HttpStatusCodes.Success, Type = typeof(PaginatedList<UserResponse>))]
    [ProducesResponseType(HttpStatusCodes.NotFound, Type = typeof(MessageDto))]
    public async Task<IActionResult> GetUsers([FromQuery] SieveModel model)
    {
        return Ok(await _userService.GetList(model));
    }

    /// <summary>
    ///     Get User data by Id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns>A <see cref="UserResponse"/> representing the asynchronous operation.</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(HttpStatusCodes.Success, Type = typeof(UserResponse))]
    [ProducesResponseType(HttpStatusCodes.NotFound, Type = typeof(MessageDto))]
    [ProducesResponseType(HttpStatusCodes.Unauthorized, Type = typeof(MessageDto))]
    [ProducesResponseType(HttpStatusCodes.BadRequest, Type = typeof(MessageDto))]
    public async Task<IActionResult> Get(Guid id)
    {
        return Ok(await _userService.GetById(id));
    }

    /// <summary>
    ///     Create User.
    /// </summary>
    /// <returns>A <see cref="MessageDto" /> representing the asynchronous operation.</returns>
    [HttpPost]
    [ProducesResponseType(HttpStatusCodes.Success, Type = typeof(MessageDto))]
    [ProducesResponseType(HttpStatusCodes.NotFound, Type = typeof(MessageDto))]
    [ProducesResponseType(HttpStatusCodes.BadRequest)]
    public async Task<IActionResult> Post([FromBody] PostUserRequest model)
    {
        if (!ModelState.IsValid)
        {
            throw new HttpResponseLibraryException(HttpStatusCodes.ErrorTransaction,
                                                   HttpStatusTitles.UnprocessableEntity,
                                                   string.Empty,
                                                   ModelState.ExtractToString());
        }

        await _userService.Create(model);

        return NoContent();
    }

    /// <summary>
    ///     Edit user.
    /// </summary>
    /// <returns>A <see cref="MessageDto" /> representing the asynchronous operation.</returns>
    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType(HttpStatusCodes.Success, Type = typeof(MessageDto))]
    [ProducesResponseType(HttpStatusCodes.NotFound, Type = typeof(MessageDto))]
    [ProducesResponseType(HttpStatusCodes.BadRequest)]
    public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] PutUserRequest model)
    {
        if (!ModelState.IsValid)
        {
            throw new HttpResponseLibraryException(HttpStatusCodes.ErrorTransaction,
                                                   HttpStatusTitles.UnprocessableEntity,
                                                   string.Empty,
                                                   ModelState.ExtractToString());
        }

        await _userService.Update(id, model);
        return NoContent();
    }

    /// <summary>
    ///     Set user to Active/Inactive.
    /// </summary>
    /// <param name="id"></param>
    /// <returns>A <see cref="MessageDto"/> representing the asynchronous operation.</returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(HttpStatusCodes.Success, Type = typeof(MessageDto))]
    [ProducesResponseType(HttpStatusCodes.NotFound, Type = typeof(MessageDto))]
    [ProducesResponseType(HttpStatusCodes.Unauthorized, Type = typeof(MessageDto))]
    [ProducesResponseType(HttpStatusCodes.BadRequest, Type = typeof(MessageDto))]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _userService.Delete(id);
        return NoContent();
    }

    /// <summary>
    ///     Get user profile.
    /// </summary>
    /// <returns>A <see cref="MessageDto" /> representing the asynchronous operation.</returns>
    [HttpGet("me")]
    [ProducesResponseType(HttpStatusCodes.Success, Type = typeof(UserProfileResponse))]
    [ProducesResponseType(HttpStatusCodes.Unauthorized, Type = typeof(MessageDto))]
    public async Task<IActionResult> GetUserProfile()
    {
        var session = await _authService.GetValidateToken(HttpContext);
        return Ok(await _userService.GetUserProfile(session));
    }

    /// <summary>
    /// Get Menu by User Login.
    /// </summary>
    /// <returns>A List of MenuResponses representing the asynchronous operation.</returns>
    [HttpGet("menus")]
    [ProducesResponseType(HttpStatusCodes.Success, Type = typeof(UserProfileResponse))]
    [ProducesResponseType(HttpStatusCodes.NotFound, Type = typeof(MessageDto))]
    [ProducesResponseType(HttpStatusCodes.Unauthorized, Type = typeof(MessageDto))]
    [ProducesResponseType(HttpStatusCodes.BadRequest, Type = typeof(MessageDto))]
    public async Task<IActionResult> GetMenuByUser()
    {
        var session = await _authService.GetValidateToken(HttpContext);
        return Ok(await _menuService.GetMenuBySession(session));
    }
}