// <copyright file="AppConfigurationRequest.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

namespace Garuda.Application.Common.Dto.Request;

public class AppConfigurationRequest
{
    public string Description { get; set; }

    public string Key { get; set; }

    public string Value { get; set; }
}