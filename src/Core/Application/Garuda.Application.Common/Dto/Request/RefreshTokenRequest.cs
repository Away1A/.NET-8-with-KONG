// <copyright file="RefreshTokenRequest.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

namespace Garuda.Application.Common.Dto.Request;

public class RefreshTokenRequest
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RefreshTokenRequest"/> class.
    /// </summary>
    /// <param name="token"></param>
    /// <param name="refreshToken"></param>
    public RefreshTokenRequest(string token, string refreshToken)
    {
        Token = token;
        RefreshToken = refreshToken;
    }

    /// <summary>
    ///     Gets or sets token.
    /// </summary>
    public string Token { get; set; }

    /// <summary>
    ///     Gets or sets user refresh token.
    /// </summary>
    public string RefreshToken { get; set; }
}