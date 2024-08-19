// <copyright file="LdapLibraryConfig.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace Garuda.Providers.Auth.LDAP.Configurations;

public class LdapLibraryConfig
{
    public LdapLibraryDefaultUser DefaultUser { get; set; }

    /// <summary>
    /// Gets or sets for LdapLibraryItems.
    /// </summary>
    public List<LdapLibraryItem> LdapLibraryItems { get; set; }
}