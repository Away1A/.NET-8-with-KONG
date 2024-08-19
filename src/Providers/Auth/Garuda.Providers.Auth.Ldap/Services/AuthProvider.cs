// <copyright file="AuthProvider.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using Garuda.Providers.Auth.Abstract.Contract;
using Garuda.Providers.Auth.Abstract.Dto;
using Garuda.Providers.Auth.LDAP.Configurations;
using Garuda.Utilities.Constants.Errors;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Novell.Directory.Ldap;

#pragma warning disable CS8603 // Possible null reference return.

namespace Garuda.Providers.Auth.LDAP.Services;

/// <summary>
/// Represents a class that provides authentication and authorization functionality.
/// </summary>
public class AuthProvider : IAuthProvider
{
    // LDAP Login attributes
    private const string MailAttribute = "mail";
    private const string DisplayNameAttribute = "displayName";
    private const string SamAccountNameAttribute = "sAMAccountName";

    private readonly LdapLibraryConfig _config;
    private readonly ILdapConnection _connection;
    private readonly ILogger _iLogger;

    /// <summary>
    /// Initializes a new instance of the <see cref="AuthProvider"/> class.
    /// </summary>
    /// <param name="config"></param>
    /// <param name="ldapConnection"></param>
    /// <param name="iLogger"></param>
    public AuthProvider(IOptions<LdapLibraryConfig> config,
                        ILdapConnection ldapConnection,
                        ILogger<AuthProvider> iLogger)
    {
        _config = config.Value;
        _connection = ldapConnection;
        _iLogger = iLogger;
    }

    public async Task<UserAuthDto> Auth(string username, string password)
    {
        foreach (var config in _config.LdapLibraryItems)
        {
            ConnectAndBindWithLdap(config, username, password);

            var searchResults = PerformLdapSearch(config, username);
            var user = FetchOneLdapEntry(searchResults, config.Domain);

            DisconnectLdap();

            return user;
        }

        await Task.Delay(1);
        throw Error.DataNotFound();
    }

    public async Task<UserAuthDto> Get(string username)
    {
        foreach (var config in _config.LdapLibraryItems)
        {
            ConnectAndBindWithLdap(config, config.Username, config.Password);

            var searchResults = PerformLdapSearch(config, username);
            var user = FetchOneLdapEntry(searchResults, config.Domain);

            DisconnectLdap();

            return user;
        }

        await Task.Delay(1);
        return null;
    }

    public async Task<List<UserAuthDto>> GetList(string parameter)
    {
        var listUser = new List<UserAuthDto>();
        foreach (var config in _config.LdapLibraryItems)
        {
            ConnectAndBindWithLdap(config, config.Username, config.Password);

            var searchResults = PerformLdapSearch(config, parameter);
            listUser.AddRange(FetchListLdapEntry(searchResults, config.Domain));

            DisconnectLdap();
        }

        await Task.Delay(1);
        return listUser;
    }

    /// <summary>
    /// Connects to LDAP server and binds with the provided credentials.
    /// </summary>
    /// <param name="ldapConfig">The LDAP configuration containing the server URL, domain, username, and password.</param>
    /// <param name="username">The username to authenticate with.</param>
    /// <param name="password">The password to authenticate with.</param>
    private void ConnectAndBindWithLdap(LdapLibraryItem ldapConfig, string username, string password)
    {
        _connection.Connect(ldapConfig.Url, LdapConnection.DefaultPort);
        _connection.Bind($"{username}@{ldapConfig.Domain}", password);
    }

    /// <summary>
    /// Disconnects from the LDAP server.
    /// </summary>
    private void DisconnectLdap()
    {
        _connection.Disconnect();
    }

    /// <summary>
    /// Performs an LDAP search based on the provided LDAP configuration and username.
    /// </summary>
    /// <param name="ldapConfig">The LDAP configuration to use for the search.</param>
    /// <param name="username">The username to search for.</param>
    /// <returns>The LDAP search results.</returns>
    private ILdapSearchResults PerformLdapSearch(LdapLibraryItem ldapConfig, string username)
    {
        return _connection.Search(ldapConfig.SearchBase,
                                  LdapConnection.ScopeSub,
                                  ldapConfig.SearchFilterLogin.Replace("%s", username),
                                  new[] { MailAttribute, DisplayNameAttribute, SamAccountNameAttribute },
                                  false);
    }

    /// <summary>
    /// Fetches a single LDAP entry from the given ILdapSearchResults object.
    /// </summary>
    /// <param name="searchResults">The ILdapSearchResults object containing the search results.</param>
    /// <param name="domain">The domain to be set for the fetched LDAP entry.</param>
    /// <returns>
    /// The fetched LDAP entry with the domain set, or null if no entry is found or an exception occurs.
    /// </returns>
    private UserAuthDto FetchOneLdapEntry(ILdapSearchResults searchResults, string domain)
    {
        while (searchResults.HasMore())
        {
            try
            {
                var entry = searchResults.Next();
                entry.Dn = domain;
                return TransformToDto(entry);
            }
            catch (LdapException e)
            {
                _iLogger.LogError(e.ToString());
                _connection.Disconnect();
            }
        }

        return null;
    }

    /// <summary>
    /// Fetches a list of LDAP entries based on the specified search parameter.
    /// </summary>
    /// <param name="searchResults">The LDAP search results.</param>
    /// <param name="domain">The domain name for the LDAP entries.</param>
    /// <returns>A list of LDAP entries.</returns>
    private List<UserAuthDto> FetchListLdapEntry(ILdapSearchResults searchResults, string domain)
    {
        var listUser = new List<UserAuthDto>();
        while (searchResults.HasMore())
        {
            try
            {
                var entry = searchResults.Next();
                entry.Dn = domain;
                listUser.Add(TransformToDto(entry));
            }
            catch (LdapException e)
            {
                _iLogger.LogError(e.ToString());
                _connection.Disconnect();
            }
        }

        return listUser;
    }

    /// <summary>
    /// Transforms an LdapEntry object to a UserAuthDto object.
    /// </summary>
    /// <param name="ldap">The LdapEntry object to transform.</param>
    /// <returns>A UserAuthDto object.</returns>
    private UserAuthDto TransformToDto(LdapEntry ldap)
    {
        return new UserAuthDto
        {
            Domain = ldap.Dn,
            Username = ldap.GetAttribute("userName").StringValue,
            Email = ldap.GetAttribute("mail").StringValue,
            Fullname = ldap.GetAttribute("displayName").StringValue
        };
    }
}