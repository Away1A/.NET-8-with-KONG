// <copyright file="MenuRequest.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
namespace Garuda.Application.Common.Dto.Request;

public class MenuRequest
{
    /// <summary>
    /// Gets or sets a value indicating whether gets or Sets for ParentId.
    /// </summary>
    public Guid? ParentId { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether gets or Sets for Code.
    /// </summary>
    public string Code { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether gets or Sets for IconClass.
    /// </summary>
    public string IconClass { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether gets or Sets for Name.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether gets or Sets for Slug.
    /// </summary>
    public string Slug { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether gets or Sets for Level.
    /// </summary>
    public int Level { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether gets or Sets for Order.
    /// </summary>
    public int Order { get; set; }
}