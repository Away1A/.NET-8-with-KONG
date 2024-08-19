// <copyright file="IAuthService.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using Garuda.Application.Common.Dto;
using Garuda.Application.Common.Dto.Request;
using Garuda.Application.Common.Dto.Response;
using Garuda.Utilities.Dtos;
using Microsoft.AspNetCore.Http;

namespace Garuda.Application.Common.Services.V1.Contracts;

/// <summary>
///     Auth Services Contract.
/// </summary>
public interface IAuthService
{
    /// <summary>
    ///     Login.
    /// </summary>
    /// <param name="model"></param>
    /// <returns>A <see cref="LoginResponse" /> representing the asynchronous operation.</returns>
    Task<LoginResponse> Login(LoginRequest model);

    /// <summary>
    ///     Log off user login.
    /// </summary>
    /// <param name="session"></param>
    /// <returns>A <see cref="Task{MessageDto}" /> representing the result of the asynchronous operation.</returns>
    Task<MessageDto> LogOff(SessionDto session);

    /// <summary>
    ///     Get user refresh token from session
    /// </summary>
    /// <param name="model"></param>
    /// <returns>A <see cref="LoginResponse" /> representing the result of the asynchronous operation.</returns>
    Task<LoginResponse> GetRefreshToken(RefreshTokenRequest model);

    /// <summary>
    /// Retrieves and validates the user session token from the HTTP context.
    /// </summary>
    /// <param name="httpContext">The HTTP context.</param>
    /// <returns>A <see cref="SessionDto"/> representing the user session.</returns>
    Task<SessionDto> GetValidateToken(HttpContext httpContext);
}