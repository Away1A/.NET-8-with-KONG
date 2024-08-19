// <copyright file="MenuPermissionResponse.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
namespace Garuda.Application.Common.Dto.Response;

public class MenuPermissionsResponse
{
    public Guid Id { get; set; }

    public Guid MenuId { get; set; }

    public string MenuLabel { get; set; }

    public int Level { get; set; }

    public bool CanView { get; set; }

    public bool CanUpdate { get; set; }

    public bool CanCreate { get; set; }

    public bool CanDelete { get; set; }
}