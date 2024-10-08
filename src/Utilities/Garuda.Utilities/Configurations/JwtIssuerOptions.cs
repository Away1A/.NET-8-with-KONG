﻿// <copyright file="JwtIssuerOptions.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using Microsoft.IdentityModel.Tokens;

namespace Garuda.Utilities.Configurations;

public class JwtIssuerOptions
{
    public string Issuer { get; set; }

    public string Subject { get; set; }

    public string Audience { get; set; }

    public string SecretKey { get; set; }

    public string RefreshSecretKey { get; set; }

    public int ExpirationTime { get; set; }

    public int RefreshExpirationTime { get; set; }

    public DateTime Expiration => IssuedAt.Add(ValidFor);

    public DateTime NotBefore => DateTime.UtcNow;

    public DateTime IssuedAt => DateTime.UtcNow;

    public TimeSpan ValidFor { get; set; } = TimeSpan.FromMinutes(120);

    public Func<Task<string>> JtiGenerator => () => Task.FromResult(Guid.NewGuid().ToString());

    public SigningCredentials SigningCredentials { get; set; }
}