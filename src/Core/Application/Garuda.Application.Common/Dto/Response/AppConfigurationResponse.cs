// <copyright file="AppConfigurationResponse.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

namespace Garuda.Application.Common.Dto.Response;

public class AppConfigurationResponse
{
    public Guid Id { get; set; }

    public string UpdatedBy { get; set; }

    public string Description { get; set; }

    public string Key { get; set; }

    public string Value { get; set; }

    public DateTime UpdatedAt { get; set; }
}