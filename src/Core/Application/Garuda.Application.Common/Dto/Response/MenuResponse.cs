// <copyright file="MenuResponse.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
namespace Garuda.Application.Common.Dto.Response;

public class MenuResponse
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Icon { get; set; }

    public string Link { get; set; }

    public string Level { get; set; }

    public MenuPermissionsResponse Permissions { get; set; }

    public List<MenuResponse> Child { get; set; } = new();
}