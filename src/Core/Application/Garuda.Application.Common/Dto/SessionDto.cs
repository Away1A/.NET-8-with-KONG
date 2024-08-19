// <copyright file="SessionDto.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
namespace Garuda.Application.Common.Dto;

public class SessionDto
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SessionDto"/> class.
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="token"></param>
    /// <param name="refreshToken"></param>
    public SessionDto(Guid userId, string token, string refreshToken)
    {
        UserId = userId;
        Token = token;
        RefreshToken = refreshToken;
    }

    public Guid UserId { get; set; }

    public string Token { get; set; }

    public string RefreshToken { get; set; }
}