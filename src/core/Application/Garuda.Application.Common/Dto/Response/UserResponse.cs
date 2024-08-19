// <copyright file="UserResponse.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using Sieve.Attributes;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace Garuda.Application.Common.Dto.Response;

public class UserResponse
{
    /// <summary>
    ///     Gets or sets a value indicating whether gets or sets for User ID
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether gets or sets for Email
    /// </summary>
    [Sieve(CanFilter = true, CanSort = true)]
    public string Email { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether gets or sets for Username
    /// </summary>
    [Sieve(CanFilter = true, CanSort = true)]
    public string Username { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether gets or sets for Domain
    /// </summary>
    public string Domain { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether gets or sets for Division
    /// </summary>
    public string Division { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether gets or sets for Department
    /// </summary>
    public string Department { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether gets or sets for WorkLocation
    /// </summary>
    public string WorkLocation { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether gets or sets for Company
    /// </summary>
    public string Company { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether gets or sets for Fullname
    /// </summary>
    [Sieve(CanFilter = true, CanSort = true)]
    public string Fullname { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether gets or sets for IsActive
    /// </summary>
    [Sieve(CanFilter = true, CanSort = true)]
    public bool IsActive { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether gets or sets for LastLogin
    /// </summary>
    public DateTime? LastLogin { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether gets or sets for UserGroups
    /// </summary>
    public List<RoleResponse> UserRoles { get; set; } = new();
}