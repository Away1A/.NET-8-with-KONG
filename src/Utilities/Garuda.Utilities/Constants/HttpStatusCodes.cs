// <copyright file="HttpStatusCodes.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

namespace Garuda.Utilities.Constants;

/// <summary>
///     Error Status Code
/// </summary>
public static class HttpStatusCodes
{
    public const int ConnectionLost = 100;

    public const int Success = 200;

    public const int Created = 201;

    public const int BadRequest = 400;

    public const int Unauthorized = 401;

    public const int InvalidCredential = 40101;

    public const int Forbidden = 403;

    public const int NotFound = 404;

    public const int Timeout = 408;

    public const int Conflict = 409;

    public const int PayloadTooLarge = 413;

    public const int UnsupportedMediaType = 415;

    public const int ErrorTransaction = 422;

    public const int InvalidSession = 440;

    public const int InternalServerError = 500;
}