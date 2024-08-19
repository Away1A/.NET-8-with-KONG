// <copyright file="UserProfileResponse.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using Garuda.Domain.Common.Models;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace Garuda.Application.Common.Dto.Response;

/// <summary>
///     Dto User Profile Responses
/// </summary>
public class UserProfileResponse
{
    /// <summary>
    ///     Gets or sets a value indicating whether gets or sets for Id
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether gets or sets for Email
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether gets or sets for Username
    /// </summary>
    public string Username { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether gets or sets for Fullname
    /// </summary>
    public string Fullname { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether gets or sets for Domain
    /// </summary>
    public string Domain { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether gets or sets for IsActive
    /// </summary>
    public bool IsActive { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether gets or sets for DefaultLandingPage
    /// </summary>
    public string DefaultLandingPage { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether gets or sets for LastLogin
    /// </summary>
    public DateTime? LastLogin { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether gets or sets for UserGroups
    /// </summary>
    public IList<UserRole> UserRoles { get; set; }
}