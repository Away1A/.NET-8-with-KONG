// <copyright file="LdapLibraryDefaultUser.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
namespace Garuda.Providers.Auth.LDAP.Configurations;

public class LdapLibraryDefaultUser
{
    public string Username { get; set; }

    public string Password { get; set; }
}