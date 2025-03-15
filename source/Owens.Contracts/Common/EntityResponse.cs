// <copyright file="EntityResponse.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;

namespace Owens.Contracts.Common
{
    /// <summary>
    /// Base class for all entity based responses.
    /// </summary>
    public abstract class EntityResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityResponse"/> class.
        /// </summary>
        /// <param name="id">The entity identifier.</param>
        protected EntityResponse(Guid id)
        {
            Id = id;
        }

        /// <summary>
        /// Gets the entity identifier. Init modifier is required for OpenAPI.
        /// </summary>
        [Required]
        public Guid Id { get; init; }
    }
}
