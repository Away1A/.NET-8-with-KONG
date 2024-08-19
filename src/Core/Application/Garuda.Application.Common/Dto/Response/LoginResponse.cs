// <copyright file="LoginResponse.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;

namespace Garuda.Application.Common.Dto.Response;

/// <summary>
///     Dto Login Responses
/// </summary>
public class LoginResponse
{
    /// <summary>
    /// Initializes a new instance of the <see cref="LoginResponse"/> class.
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="token"></param>
    /// <param name="refreshToken"></param>
    public LoginResponse(Guid userId, string token, string refreshToken)
    {
        UserId = userId;
        Token = token;
        RefreshToken = refreshToken;
    }

    /// <summary>
    ///     Gets or Sets for UserId
    /// </summary>
    [Required]
    public Guid UserId { get; set; }

    /// <summary>
    ///     Gets or sets for Tokens
    /// </summary>
    [Required]
    public string Token { get; set; }

    /// <summary>
    ///     Gets or sets for RefreshTokens
    /// </summary>
    [Required]
    public string RefreshToken { get; set; }
}