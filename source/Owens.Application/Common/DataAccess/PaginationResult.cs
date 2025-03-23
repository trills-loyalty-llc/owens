// <copyright file="PaginationResult.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using Owens.Domain.Common;

namespace Owens.Application.Common.DataAccess
{
    /// <summary>
    /// Result object for a pagination query.
    /// </summary>
    /// <typeparam name="TAggregateRoot">The type of the root.</typeparam>
    public class PaginationResult<TAggregateRoot>
        where TAggregateRoot : IAggregateRoot
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PaginationResult{TAggregateRoot}"/> class.
        /// </summary>
        /// <param name="roots">A result list from the query.</param>
        /// <param name="totalCount">The total count from the query.</param>
        public PaginationResult(List<TAggregateRoot> roots, int totalCount)
        {
            Roots = roots;
            TotalCount = totalCount;
        }

        /// <summary>
        /// Gets the result list.
        /// </summary>
        public List<TAggregateRoot> Roots { get; }

        /// <summary>
        /// Gets the total count.
        /// </summary>
        public int TotalCount { get; }
    }
}
