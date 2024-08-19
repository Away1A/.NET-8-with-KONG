// <copyright file="IAnimalRepository.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using Garuda.Domain.Common.Models;
using Garuda.Persistences.Abstract.Contracts;

namespace Garuda.Repository.Common.Repositories.Contracts
{
    /// <summary>
    /// Represents a repository for managing animals.
    /// </summary>
    public interface IAnimalRepository : IRepository
    {
        /// <summary>
        /// Retrieves a queryable collection of all animals from the repository.
        /// </summary>
        /// <returns>An IQueryable of the Animal entity.</returns>
        IQueryable<Animal> Query();

        /// <summary>
        /// Gets an animal by its ID.
        /// </summary>
        /// <param name="id">The ID of the animal.</param>
        /// <returns>A Task representing the asynchronous operation. The task result contains the Animal with the specified ID, or null if not found.</returns>
        Task<Animal?> Get(Guid id);

        /// <summary>
        /// Creates a new animal in the repository.
        /// </summary>
        /// <param name="model">The animal to create.</param>
        /// <returns>A Task representing the asynchronous operation. The task result contains the created Animal.</returns>
        Task<Animal> Create(Animal model);

        /// <summary>
        /// Updates an existing animal in the repository.
        /// </summary>
        /// <param name="id">The ID of the animal to update.</param>
        /// <param name="model">The updated Animal object.</param>
        /// <returns>A Task representing the asynchronous operation. The task result contains the updated Animal object.</returns>
        Task<Animal> Update(Guid id, Animal model);

        /// <summary>
        /// Deletes an animal from the repository.
        /// </summary>
        /// <param name="id">The ID of the animal to delete.</param>
        /// <returns>A Task representing the asynchronous operation. The task result contains the deleted Animal.</returns>
        Task<Animal> Delete(Guid id);

        /// <summary>
        /// Validates if there is a duplicate animal with the same name in the repository.
        /// </summary>
        /// <param name="id">The ID of the animal to exclude from the duplicate check. Null if creating a new animal.</param>
        /// <param name="name">The name of the animal.</param>
        /// <param name="isActive">Indicates whether the animal is active or not.</param>
        /// <returns>A Task representing the asynchronous operation. If a duplicate is found, an exception will be thrown.</returns>
        Task ValidateAndHandleDuplicate(Guid? id, string name, bool isActive);
    }
}
