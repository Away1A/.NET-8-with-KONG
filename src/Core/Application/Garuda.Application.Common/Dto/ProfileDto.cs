// <copyright file="ProfileDto.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
namespace Garuda.Application.Common.Dto;

public class ProfileDto
{
    public string FullName { get; set; }

    public string Email { get; set; }

    public string PhoneNumber { get; set; }

    public string PictureUrl { get; set; }

    public List<string> UserRoles { get; set; }
}