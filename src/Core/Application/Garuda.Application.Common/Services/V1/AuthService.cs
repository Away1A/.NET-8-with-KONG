// <copyright file="AuthService.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Garuda.Application.Common.Dto;
using Garuda.Application.Common.Dto.Request;
using Garuda.Application.Common.Dto.Response;
using Garuda.Application.Common.Services.V1.Contracts;
using Garuda.Domain.Common.Models;
using Garuda.Persistences.Abstract.Contracts;
using Garuda.Repository.Common.Repositories.Contracts;
using Garuda.Utilities.Configurations;
using Garuda.Utilities.Constants.Errors;
using Garuda.Utilities.Dtos;
using Garuda.Utilities.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Garuda.Application.Common.Services.V1;

public class AuthService : IAuthService
{
    private readonly IStorage _storage;
    private readonly ILogger _logger;
    private readonly JwtIssuerOptions _jwtIssuerOptions;

    /// <summary>
    /// Initializes a new instance of the <see cref="AuthService"/> class.
    /// </summary>
    /// <param name="storage"></param>
    /// <param name="logger"></param>
    /// <param name="jwtIssuerOptions"></param>
    public AuthService(IStorage storage, ILogger<AuthService> logger, IOptions<JwtIssuerOptions> jwtIssuerOptions)
    {
        _storage = storage;
        _logger = logger;
        _jwtIssuerOptions = jwtIssuerOptions.Value;
    }

    public async Task<LoginResponse> Login(LoginRequest model)
    {
        var user = await _storage.GetRepository<IUserRepository>()
                                 .GetAndValidateUsernameAndPassword(model.Username, model.Password);
        user.LastLogin = DateTime.Now;

        var token = GenerateJwt(user, _jwtIssuerOptions.ExpirationTime);
        var refreshToken = GenerateRefreshToken();

        await CreateUserSession(user, token, refreshToken);
        await _storage.SaveAsync();
        return new LoginResponse(user.Id, token, refreshToken);
    }

    public async Task<MessageDto> LogOff(SessionDto session)
    {
        await _storage.GetRepository<IUserSessionRepository>().RevokeToken(session.Token);

        return new MessageDto("You've been logged out from apps");
    }

    public async Task<LoginResponse> GetRefreshToken(RefreshTokenRequest refreshToken)
    {
        _ = ValidateToken(refreshToken.RefreshToken);

        var userSession = await _storage.GetRepository<IUserSessionRepository>()
                                        .GetAndValidateRefreshToken(refreshToken.RefreshToken);
        var user = await _storage.GetRepository<IUserRepository>().GetAndValidateById(userSession.UserId);
        var newToken = GenerateJwt(user, _jwtIssuerOptions.ExpirationTime);
        var newRefreshToken = GenerateRefreshToken();

        userSession.Token = newToken;
        userSession.RefreshToken = newRefreshToken;

        await _storage.SaveAsync();

        return new LoginResponse(user.Id, newToken, newRefreshToken);
    }

    public async Task<SessionDto> GetValidateToken(HttpContext httpContext)
    {
        var userId = ValidateHttpContext(httpContext);
        var userSession = await _storage.GetRepository<IUserSessionRepository>().GetAndValidateByUserId(userId);

        _ = ValidateToken(userSession.Token);

        return new SessionDto(userSession.UserId, userSession.Token, userSession.RefreshToken);
    }

    /// <summary>
    /// Creates a new user session in the database.
    /// </summary>
    /// <param name="user">The user object.</param>
    /// <param name="token">The authentication token.</param>
    /// <param name="refreshToken">The refresh token.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    private async Task CreateUserSession(User user, string token, string refreshToken)
    {
        await _storage.GetRepository<IUserSessionRepository>()
                      .Create(new UserSession
                      {
                          DateExpired = DateTime.UtcNow.AddSeconds(_jwtIssuerOptions.ExpirationTime),
                          RefreshToken = refreshToken,
                          Token = token,
                          UserId = user.Id,
                      });
    }

    /// <summary>
    /// Generate JWT token.
    /// </summary>
    /// <param name="user"></param>
    /// <param name="expiredInMinutes"></param>
    /// <returns>string of jwt token.</returns>
    private string GenerateJwt(User user, int expiredInMinutes)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtIssuerOptions.SecretKey));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        var claims = CreateClaims(user);
        var token = CreateJwtToken(claims, credentials, DateTime.UtcNow.AddSeconds(expiredInMinutes));
        var tokenHandler = new JwtSecurityTokenHandler();

        return tokenHandler.WriteToken(token);
    }

    /// <summary>
    /// Generates a refresh token.
    /// </summary>
    /// <returns>A string representing the generated refresh token.</returns>
    private string GenerateRefreshToken()
    {
        var randomNumber = new byte[32];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomNumber);
        return Convert.ToBase64String(randomNumber);
    }

    /// <summary>
    /// Creates a JWT token with the specified claims, signing credentials, and expiration date.
    /// </summary>
    /// <param name="claims">The claims to be included in the token.</param>
    /// <param name="credentials">The signing credentials used to sign the token.</param>
    /// <param name="expiration">The expiration date and time of the token.</param>
    /// <returns>The created JWT token.</returns>
    private JwtSecurityToken CreateJwtToken(List<Claim> claims, SigningCredentials credentials, DateTime expiration) =>
        new(_jwtIssuerOptions.Issuer,
            _jwtIssuerOptions.Audience,
            claims,
            expires: expiration,
            signingCredentials: credentials);

    private List<Claim> CreateClaims(User user)
    {
        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, _jwtIssuerOptions.SecretKey),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString()),
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new(ClaimTypes.Name, user.Fullname),
            new(ClaimTypes.Email, user.Email),
            new(ClaimTypes.Role, user.UserRoles.FirstOrDefault()?.Role.Name ?? "Administrator")
        };

        return claims;
    }

    /// <summary>
    /// Validate JWT token.
    /// </summary>
    /// <param name="token"></param>
    /// <returns>return JwtSecurityToken.</returns>
    private JwtSecurityToken ValidateToken(string token)
    {
        var validationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = _jwtIssuerOptions.Issuer,
            ValidateIssuerSigningKey = true,
            ValidateLifetime = true,
            ValidateAudience = false,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtIssuerOptions.SecretKey))
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        tokenHandler.ValidateToken(token, validationParameters, out SecurityToken validatedToken);

        return (JwtSecurityToken)validatedToken;
    }

    /// <summary>
    /// Validates the HttpContext and retrieves the user ID from the Claims.
    /// </summary>
    /// <param name="httpContext">The HttpContext to validate.</param>
    /// <returns>The user ID as a Guid.</returns>
    private Guid ValidateHttpContext(HttpContext httpContext)
    {
        var userId = httpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (userId == null)
        {
            throw Error.Unauthorized();
        }

        return Guid.Parse(userId);
    }
}