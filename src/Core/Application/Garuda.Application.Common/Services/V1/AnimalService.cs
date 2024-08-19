// <copyright file="AnimalService.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using Garuda.Application.Common.Dto.Request;
using Garuda.Application.Common.Dto.Response;
using Garuda.Application.Common.Services.V1.Contracts;
using Garuda.Domain.Common.Models;
using Garuda.Persistences.Abstract.Contracts;
using Garuda.Repository.Common.Repositories.Contracts;
using Garuda.Utilities.Dtos;
using Garuda.Utilities.Dtos.Response;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Sieve.Models;
using Sieve.Services;

namespace Garuda.Application.Common.Services.V1
{
    public class AnimalService : IAnimalService
    {
        private readonly IStorage _storage;
        private readonly ISieveProcessor _sieveProcessor;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="AnimalService"/> class.
        /// </summary>
        /// <param name="storage">The storage service for repository access.</param>
        /// <param name="sieveProcessor">The Sieve processor for query filtering and sorting.</param>
        /// <param name="mapper">The mapper for object mapping.</param>
        public AnimalService(IStorage storage, ISieveProcessor sieveProcessor, IMapper mapper)
        {
            _storage = storage;
            _sieveProcessor = sieveProcessor;
            _mapper = mapper;
        }

        /// <summary>
        /// Retrieves an animal by its ID.
        /// </summary>
        /// <param name="id">The ID of the animal.</param>
        /// <returns>A task representing the asynchronous operation, with the animal response as the result.</returns>
        public async Task<AnimalResponse?> Get(Guid id)
        {
            var animal = await _storage.GetRepository<IAnimalRepository>()
                                       .Query()
                                       .FirstOrDefaultAsync(x => x.Id == id);

            return _mapper.Map<Animal, AnimalResponse>(animal);
        }

        /// <summary>
        /// Retrieves a paginated list of animals based on the provided sieve model.
        /// </summary>
        /// <param name="sieveModel">The sieve model containing filtering and sorting criteria.</param>
        /// <returns>A task representing the asynchronous operation, with a paginated list of animal responses as the result.</returns>
        public async Task<PaginatedList<AnimalResponse>> GetList(SieveModel sieveModel)
        {
            var query = _storage.GetRepository<IAnimalRepository>()
                                .Query()
                                .IgnoreQueryFilters()
                                .ProjectToType<AnimalResponse>();

            var filteredQuery = _sieveProcessor.Apply(sieveModel, query);
            return await PaginatedList<AnimalResponse>.CreateAsync(filteredQuery,
                                                                 sieveModel.Page ?? 1,
                                                                 sieveModel.PageSize ?? 10);
        }

        /// <summary>
        /// Creates a new animal in the repository.
        /// </summary>
        /// <param name="model">The animal request model containing the data to create.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task Create(AnimalRequest model)
        {
            var animal = _mapper.Map<AnimalRequest, Animal>(model);
            await _storage.GetRepository<IAnimalRepository>().Create(animal);
            await _storage.SaveAsync();
        }

        /// <summary>
        /// Updates an existing animal in the repository.
        /// </summary>
        /// <param name="id">The ID of the animal to update.</param>
        /// <param name="model">The animal request model containing the updated data.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task Update(Guid id, AnimalRequest model)
        {
            var animal = await _storage.GetRepository<IAnimalRepository>().Get(id);
            if (animal == null)
            {
                throw new KeyNotFoundException("Animal not found.");
            }

            // Map updates from model to existing animal
            _mapper.Map(model, animal);
            animal.UpdatedDate = DateTime.UtcNow;

            await _storage.GetRepository<IAnimalRepository>().Update(id, animal);
            await _storage.SaveAsync();
        }

        /// <summary>
        /// Deletes an animal from the repository.
        /// </summary>
        /// <param name="id">The ID of the animal to delete.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task Delete(Guid id)
        {
            var animal = await _storage.GetRepository<IAnimalRepository>().Get(id);
            if (animal == null)
            {
                throw new KeyNotFoundException("Animal not found.");
            }

            await _storage.GetRepository<IAnimalRepository>().Delete(id);
            await _storage.SaveAsync();
        }

        /// <summary>
        /// Retrieves a list of animals based on their active status.
        /// </summary>
        /// <param name="isActive">Indicates whether to retrieve active or inactive animals.</param>
        /// <returns>A task representing the asynchronous operation, with a list of animal responses as the result.</returns>
        public async Task<List<AnimalResponse>> GetData(bool isActive)
        {
            return await _storage.GetRepository<IAnimalRepository>()
                                 .Query()
                                 .IgnoreQueryFilters()
                                 .Where(x => isActive ? x.DeletedDate == null : x.DeletedDate != null)
                                 .ProjectToType<AnimalResponse>()
                                 .ToListAsync();
        }
    }
}
