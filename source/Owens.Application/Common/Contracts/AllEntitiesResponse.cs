// <copyright file="AllEntitiesResponse.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;

namespace Owens.Application.Common.Contracts
{
    /// <summary>
    /// Base class for a get all response.
    /// </summary>
    /// <typeparam name="TResponse">The type of the response.</typeparam>
    public abstract class AllEntitiesResponse<TResponse>
        where TResponse : EntityResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AllEntitiesResponse{TResponse}"/> class.
        /// </summary>
        /// <param name="entities">An <see cref="IEnumerable{T}"/> of entities.</param>
        protected AllEntitiesResponse(IEnumerable<TResponse> entities)
        {
            Entities = entities;
        }

        /// <summary>
        /// Gets all entities from the response.
        /// </summary>
        [Required]
        public IEnumerable<TResponse> Entities { get; }
    }
}
