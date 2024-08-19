// <copyright file="GlobalConfiguration.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
namespace Garuda.Utilities;

public class GlobalConfiguration
{
    public static string DefaultCulture => "en-US";

    public static string WebRootPath { get; set; }

    public static string ContentRootPath { get; set; }
}