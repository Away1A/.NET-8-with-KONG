// <copyright file="ManageSecurityDetailsResponse.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace Garuda.Application.Common.Dto.Response;

public class ManageSecurityDetailsResponse
{
    public string Name { get; set; }

    public bool IsActive { get; set; }

    public Guid Id { get; set; }

    public List<MenuPermissionsResponse> Permissions { get; set; } = new();
}