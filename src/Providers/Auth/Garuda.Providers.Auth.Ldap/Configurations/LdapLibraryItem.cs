// <copyright file="LdapLibraryItem.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
namespace Garuda.Providers.Auth.LDAP.Configurations;

public class LdapLibraryItem
{
    /// <summary>
    /// Gets or sets for Url.
    /// </summary>
    public string Url { get; set; }

    /// <summary>
    /// Gets or sets for Domain.
    /// </summary>
    public string Domain { get; set; }

    /// <summary>
    /// Gets or sets for SearchBase.
    /// </summary>
    public string SearchBase { get; set; }

    /// <summary>
    /// Gets or sets for SearchFilter.
    /// </summary>
    public string SearchFilter { get; set; }

    /// <summary>
    /// Gets or sets for SearchFilterLogin.
    /// </summary>
    public string SearchFilterLogin { get; set; }

    /// <summary>
    /// Gets or sets for Username.
    /// </summary>
    public string Username { get; set; }

    /// <summary>
    /// Gets or sets for Password.
    /// </summary>
    public string Password { get; set; }
}