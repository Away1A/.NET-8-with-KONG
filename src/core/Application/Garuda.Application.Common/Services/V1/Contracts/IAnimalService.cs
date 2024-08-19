using Garuda.Application.Common.Dto.Request;
using Garuda.Application.Common.Dto.Response;
using Garuda.Utilities.Dtos;
using Garuda.Utilities.Dtos.Response;
using Sieve.Models;

namespace Garuda.Application.Common.Services.V1.Contracts
{
    /// <summary>
    /// Represents a service for managing animals.
    /// </summary>
    public interface IAnimalService
    {
        /// <summary>
        /// Retrieves a paginated list of animals based on the provided SieveModel.
        /// </summary>
        /// <param name="sieveModel">The SieveModel object for pagination and filtering.</param>
        /// <returns>A Task representing the asynchronous operation. The task result contains a paginated list of AnimalResponse objects.</returns>
        Task<PaginatedList<AnimalResponse>> GetList(SieveModel sieveModel);

        /// <summary>
        /// Retrieves a specific animal by ID.
        /// </summary>
        /// <param name="id">The ID of the animal.</param>
        /// <returns>A Task representing the asynchronous operation. The task result contains an AnimalResponse object.</returns>
        Task<AnimalResponse> Get(Guid id);

        /// <summary>
        /// Creates a new animal.
        /// </summary>
        /// <param name="model">The AnimalRequest object that contains the animal details.</param>
        /// <returns>A Task representing the asynchronous operation.</returns>
        Task Create(AnimalRequest model);

        /// <summary>
        /// Updates an existing animal.
        /// </summary>
        /// <param name="id">The ID of the animal to update.</param>
        /// <param name="model">The AnimalRequest object that contains the updated animal details.</param>
        /// <returns>A Task representing the asynchronous operation.</returns>
        Task Update(Guid id, AnimalRequest model);

        /// <summary>
        /// Deletes a specific animal by ID.
        /// </summary>
        /// <param name="id">The ID of the animal to delete.</param>
        /// <returns>A Task representing the asynchronous operation.</returns>
        Task Delete(Guid id);
    }
}
