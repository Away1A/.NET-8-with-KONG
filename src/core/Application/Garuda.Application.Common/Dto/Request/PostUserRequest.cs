// <copyright file="PostUserRequest.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace Garuda.Application.Common.Dto.Request;

public class PostUserRequest
{
    /// <summary>
    ///     Gets or sets a value indicating whether gets or sets for Email
    /// </summary>
    [Required(ErrorMessage = "Email field is required.")]
    [EmailAddress(ErrorMessage = "Invalid Email Address")]
    public string Email { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether gets or sets for Username
    /// </summary>
    [Required(ErrorMessage = "The Username field is required.")]
    public string Username { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether gets or sets for Username
    /// </summary>
    [Required(ErrorMessage = "The Fullname field is required.")]
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
    ///     Gets or sets a value indicating whether gets or sets for LastLogin
    /// </summary>
    public DateTime? LastLogin { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether gets or sets for UserGroups
    /// </summary>
    [Required(ErrorMessage = "User Role cannot be null.")]
    public List<RoleRequest> UserRoles { get; set; }
}