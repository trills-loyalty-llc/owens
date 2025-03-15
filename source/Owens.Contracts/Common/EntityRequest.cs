// <copyright file="EntityRequest.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;

namespace Owens.Contracts.Common
{
    /// <summary>
    /// Request object for all entities.
    /// </summary>
    public abstract class EntityRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityRequest"/> class.
        /// </summary>
        /// <param name="id">The entity identifier.</param>
        protected EntityRequest(Guid id)
        {
            Id = id;
        }

        /// <summary>
        /// Gets the identifier.
        /// </summary>
        [Required]
        public Guid Id { get; }
    }
}
