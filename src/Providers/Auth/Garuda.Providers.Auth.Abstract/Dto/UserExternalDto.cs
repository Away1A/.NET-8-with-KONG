// <copyright file="UserExternalDto.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
namespace Garuda.Providers.Auth.Abstract.Dto;

public class UserAuthDto
{
    public string Company { get; set; }

    public string Department { get; set; }

    public string Domain { get; set; }

    public string Email { get; set; }

    public string Fullname { get; set; }

    public string Username { get; set; }

    public string WorkLocation { get; set; }
}