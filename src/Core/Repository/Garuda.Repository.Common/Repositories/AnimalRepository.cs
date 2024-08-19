// <copyright file="AnimalRepository.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using Garuda.Domain.Common.Models;
using Garuda.Persistences.Framework;
using Garuda.Repository.Common.Repositories.Contracts;
using Garuda.Utilities.Constants.Errors;
using Microsoft.EntityFrameworkCore;

namespace Garuda.Repository.Common.Repositories
{
    public class AnimalRepository : RepositoryBase<Animal>, IAnimalRepository
    {
        /// <summary>
        /// Retrieve the IQueryable for querying animals.
        /// </summary>
        /// <returns>IQueryable of Animal.</returns>
        public IQueryable<Animal> Query()
        {
            return this.dbSet.AsQueryable();
        }

        /// <summary>
        /// Retrieve an animal by its ID.
        /// </summary>
        /// <param name="id">The ID of the animal.</param>
        /// <returns>The Animal object or null if not found.</returns>
        public async Task<Animal?> Get(Guid id)
        {
            return await this.dbSet.FindAsync(id);
        }

        /// <summary>
        /// Retrieve all animals.
        /// </summary>
        /// <returns>List of all Animal objects.</returns>
        public async Task<List<Animal>> GetAll()
        {
            return await this.dbSet.ToListAsync();
        }

        /// <summary>
        /// Create a new animal entry in the database.
        /// </summary>
        /// <param name="model">The Animal object to create.</param>
        /// <returns>The created Animal object.</returns>
        public async Task<Animal> Create(Animal model)
        {
            await this.dbSet.AddAsync(model);
            return model;
        }

        /// <summary>
        /// Update an existing animal entry.
        /// </summary>
        /// <param name="id">The ID of the animal to update.</param>
        /// <param name="model">The updated Animal data.</param>
        /// <returns>The updated Animal object.</returns>
        public async Task<Animal> Update(Guid id, Animal model)
        {
            var animal = await this.dbSet.FindAsync(id);
            if (animal == null)
            {
                throw Error.DataNotFound();
            }

            // Update properties
            animal.Name = model.Name;
            animal.Type = model.Type;
            animal.Gender = model.Gender;
            animal.Age = model.Age;
            animal.Price = model.Price;
            animal.Description = model.Description;
            animal.Status = model.Status;
            animal.ApprovedBy = model.ApprovedBy;
            animal.ApprovedDate = model.ApprovedDate;
            animal.RejectedBy = model.RejectedBy;
            animal.RejectionReason = model.RejectionReason;
            animal.RejectedDate = model.RejectedDate;
            animal.PermittedBy = model.PermittedBy;
            animal.PermittedDate = model.PermittedDate;
            animal.UpdatedDate = DateTime.UtcNow;

            this.dbSet.Update(animal);
            return animal;
        }

        /// <summary>
        /// Delete an animal entry by its ID.
        /// </summary>
        /// <param name="id">The ID of the animal to delete.</param>
        /// <returns>The deleted Animal object.</returns>
        public async Task<Animal> Delete(Guid id)
        {
            var animal = await this.dbSet.FindAsync(id);
            if (animal == null)
            {
                throw Error.DataNotFound();
            }

            this.dbSet.Remove(animal);
            return animal;
        }

        /// <summary>
        /// Validate and handle duplicate animal entries by name.
        /// </summary>
        /// <param name="id">The ID of the animal (null for new entries).</param>
        /// <param name="name">The name of the animal to check.</param>
        /// <param name="isActive">Flag indicating if the validation is for active animals.</param>
        /// <returns>A Task representing the asynchronous operation.</returns>
        public async Task ValidateAndHandleDuplicate(Guid? id, string name, bool isActive)
        {
            var query = this.dbSet.AsQueryable();

            if (id.HasValue)
            {
                query = query.Where(x => x.Id != id &&
                                         x.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase) &&
                                         (isActive ? x.DeletedDate == null : x.DeletedDate != null));
            }
            else
            {
                query = query.Where(x => x.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase) &&
                                         (isActive ? x.DeletedDate == null : x.DeletedDate != null));
            }

            var animal = await query.FirstOrDefaultAsync();
            if (animal != null)
            {
                throw Error.Conflict();
            }
        }
    }
}
