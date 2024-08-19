// <copyright file="AnimalRequest.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace Garuda.Application.Common.Dto.Request
{
    /// <summary>
    /// Represents the request model for creating or updating an animal.
    /// </summary>
    public class AnimalRequest
    {
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
        /// Gets or sets the status of the animal.
        /// </summary>
        public string Status { get; set; }
    }
}
