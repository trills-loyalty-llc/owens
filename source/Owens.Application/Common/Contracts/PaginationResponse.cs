// <copyright file="PaginationResponse.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;

namespace Owens.Application.Common.Contracts
{
    /// <summary>
    /// A common response for pagination.
    /// </summary>
    /// <typeparam name="TEntity">The type of the returned entity.</typeparam>
    public abstract class PaginationResponse<TEntity>
        where TEntity : EntityResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PaginationResponse{TEntity}"/> class.
        /// </summary>
        /// <param name="entities">A <see cref="List{T}"/> of entities.</param>
        /// <param name="totalCount">The total count from the query.</param>
        protected PaginationResponse(IEnumerable<TEntity> entities, int totalCount)
        {
            Entities = entities;
            TotalCount = totalCount;
        }

        /// <summary>
        /// Gets the paginated entities.
        /// </summary>
        [Required]
        public IEnumerable<TEntity> Entities { get; init; }

        /// <summary>
        /// Gets the total paginated count.
        /// </summary>
        [Required]
        public int TotalCount { get; init; }
    }
}
