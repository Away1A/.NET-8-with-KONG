// <copyright file="AnimalResponse.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

namespace Garuda.Application.Common.Dto.Response
{
    /// <summary>
    /// Represents the response model for an animal.
    /// </summary>
    public class AnimalResponse
    {
        /// <summary>
        /// Gets or sets the ID of the animal.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the animal.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the type of the animal (e.g., Mammal, Bird).
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the gender of the animal.
        /// </summary>
        public string Gender { get; set; }

        /// <summary>
        /// Gets or sets the age of the animal.
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// Gets or sets the price of the animal.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the description of the animal.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the animal was last updated.
        /// </summary>
        public DateTime UpdatedDate { get; set; }
    }
}
