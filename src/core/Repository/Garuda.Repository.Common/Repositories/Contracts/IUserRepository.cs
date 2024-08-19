// <copyright file="IUserRepository.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using Garuda.Domain.Common.Models;
using Garuda.Persistences.Abstract.Contracts;

namespace Garuda.Repository.Common.Repositories.Contracts;

/// <summary>
/// Represents a repository for managing user data.
/// </summary>
public interface IUserRepository : IRepository
{
    /// <summary>
    /// Retrieves a queryable representation of the User entities.
    /// </summary>
    /// <returns>A <see cref="IQueryable{User}"/> representing the queryable User entities.</returns>
    IQueryable<User> Query();

    /// <summary>
    /// Retrieves a user by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the user.</param>
    /// <returns>The user associated with the specified identifier.</returns>
    Task<User> Get(Guid id);

    /// <summary>
    /// Creates a new user.
    /// </summary>
    /// <param name="model">The user model to be created.</param>
    /// <returns>The created user.</returns>
    Task<User> Create(User model);

    /// <summary>
    /// Updates a user with the specified id using the provided model.
    /// </summary>
    /// <param name="id">The id of the user to update.</param>
    /// <param name="model">The updated user model.</param>
    /// <returns>The updated user.</returns>
    Task<User> Update(Guid id, User model);

    /// <summary>
    /// Delete a user with the specified identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the user.</param>
    /// <returns>The updated user.</returns>
    Task<User> Delete(Guid id);

    /// <summary>
    /// Retrieves and validates a user by their ID.
    /// </summary>
    /// <param name="id">The ID of the user to retrieve and validate.</param>
    /// <returns>The retrieved and validated user.</returns>
    Task<User> GetAndValidateById(Guid id);

    /// <summary>
    /// Validates if a user with the given name already exists in the database.
    /// </summary>
    /// <param name="name">The name of the user to validate.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task ValidateDuplicateByName(string name);

    /// <summary>
    /// Validates if there is a duplicate User with the same ID and Name.
    /// </summary>
    /// <param name="id">The ID of the User to validate.</param>
    /// <param name="name">The Name of the User to validate.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous validation operation.</returns>
    Task ValidateDuplicateByIdAndByName(Guid id, string name);

    /// <summary>
    /// Retrieves and validates a user's username and password.
    /// </summary>
    /// <param name="username">The username.</param>
    /// <param name="password">The password.</param>
    /// <returns>The user object if the username and password are correct; otherwise, null.</returns>
    Task<User> GetAndValidateUsernameAndPassword(string username, string password);
}