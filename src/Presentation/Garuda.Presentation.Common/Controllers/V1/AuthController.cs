// <copyright file="AuthController.cs" company="CV Garuda Infinity Kreasindo">
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
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Garuda.Presentation.Common.Controllers.V1;

/// <summary>
/// Auth Application Endpoint
/// </summary>
[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/auth")]
[Produces("application/json")]
[Tags("Authentication")]
public class AuthController : Controller
{
    private readonly IAuthService _authService;

    /// <summary>
    ///     Initializes a new instance of the <see cref="AuthController" /> class.
    /// </summary>
    /// <param name="authService"></param>
    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    /// <summary>
    ///     Login Apps.
    /// </summary>
    /// <returns>A <see cref="LoginResponse" /> representing the asynchronous operation.</returns>
    [HttpPost]
    [Route("login")]
    [ProducesResponseType(HttpStatusCodes.Success, Type = typeof(LoginResponse))]
    [ProducesResponseType(HttpStatusCodes.NotFound, Type = typeof(MessageDto))]
    [ProducesResponseType(HttpStatusCodes.InvalidCredential, Type = typeof(MessageDto))]
    [ProducesResponseType(HttpStatusCodes.ErrorTransaction, Type = typeof(MessageDto))]
    [ProducesResponseType(HttpStatusCodes.BadRequest, Type = typeof(MessageDto))]
    public async Task<IActionResult> Login([FromBody] LoginRequest model)
    {
        if (!ModelState.IsValid)
        {
            throw new HttpResponseLibraryException(HttpStatusCodes.ErrorTransaction,
                                                   HttpStatusTitles.UnprocessableEntity,
                                                   string.Empty,
                                                   ModelState.ExtractToString());
        }

        return Ok(await _authService.Login(model));
    }

    /// <summary>
    ///     Logout from Apps.
    /// </summary>
    /// <returns>A <see cref="MessageDto" /> representing the asynchronous operation.</returns>
    [Authorize]
    [HttpPost]
    [Route("logout")]
    [ProducesResponseType(HttpStatusCodes.Success, Type = typeof(MessageDto))]
    [ProducesResponseType(HttpStatusCodes.Unauthorized, Type = typeof(MessageDto))]
    [ProducesResponseType(HttpStatusCodes.InvalidSession, Type = typeof(MessageDto))]
    [ProducesResponseType(HttpStatusCodes.BadRequest, Type = typeof(MessageDto))]
    public async Task<IActionResult> LogOffRequest()
    {
        var session = await _authService.GetValidateToken(HttpContext);
        return Ok(await _authService.LogOff(session));
    }

    /// <summary>
    ///     Get refresh token from user session
    /// </summary>
    /// <param name="model"></param>
    /// <returns>A <see cref="LoginResponse" /> representing the asynchronous operation.</returns>
    [Authorize]
    [HttpPost]
    [Route("refresh-token")]
    [ProducesResponseType(HttpStatusCodes.Success, Type = typeof(LoginResponse))]
    [ProducesResponseType(HttpStatusCodes.Unauthorized, Type = typeof(MessageDto))]
    [ProducesResponseType(HttpStatusCodes.InvalidSession, Type = typeof(MessageDto))]
    [ProducesResponseType(HttpStatusCodes.BadRequest, Type = typeof(MessageDto))]
    public async Task<IActionResult> GetRefreshToken([FromBody] RefreshTokenRequest model)
    {
        _ = await _authService.GetValidateToken(HttpContext);
        return Ok(await _authService.GetRefreshToken(model));
    }
}