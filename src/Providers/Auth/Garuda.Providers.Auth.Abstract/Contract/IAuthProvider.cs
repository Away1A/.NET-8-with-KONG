// <copyright file="IAuthProvider.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using Garuda.Providers.Auth.Abstract.Dto;

namespace Garuda.Providers.Auth.Abstract.Contract;

/// <summary>
/// Represents an interface for providing authentication and authorization functionality.
/// </summary>
public interface IAuthProvider<T>
    where T : new()
{
    /// <summary>
    /// Authenticates a user with the given username and password.
    /// </summary>
    /// <typeparam name="T">The type of object to return after authentication.</typeparam>
    /// <param name="username">The username of the user.</param>
    /// <param name="password">The password of the user.</param>
    /// <returns>A task representing the asynchronous operation. The task result is the authenticated object of type T.</returns>
    Task<T> Auth(string username, string password);
}

/// <summary>
/// Represents an interface for providing authentication and authorization functionality.
/// </summary>
public interface IAuthProvider
{
    /// <summary>
    /// Authenticates a user with the given username and password.
    /// </summary>
    /// <typeparam name="T">The type of object to return after authentication.</typeparam>
    /// <param name="username">The username of the user.</param>
    /// <param name="password">The password of the user.</param>
    /// <returns>A task representing the asynchronous operation. The task result is the authenticated object of type T.</returns>
    Task<UserAuthDto> Auth(string username, string password);

    /// <summary>
    /// Retrieves an object of type T for the specified username.
    /// </summary>
    /// <typeparam name="T">The type of object to retrieve.</typeparam>
    /// <param name="username">The username of the user.</param>
    /// <returns>A task representing the asynchronous operation. The task result is the retrieved object of type T.</returns>
    Task<UserAuthDto> Get(string username);

    /// <summary>
    /// Retrieves a list of objects of type T based on the given parameter.
    /// </summary>
    /// <typeparam name="T">The type of objects to retrieve.</typeparam>
    /// <param name="parameter">The parameter to filter the list of objects.</param>
    /// <returns>A task representing the asynchronous operation. The task result is the list of retrieved objects of type T.</returns>
    Task<List<UserAuthDto>> GetList(string parameter);
}