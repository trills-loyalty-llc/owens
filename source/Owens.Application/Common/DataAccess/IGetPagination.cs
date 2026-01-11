// <copyright file="IGetPagination.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using ClearDomain.GuidPrimary;

namespace Owens.Application.Common.DataAccess
{
    /// <summary>
    /// Interface to define a pagination operation.
    /// </summary>
    /// <typeparam name="TAggregateRoot">The type of the root.</typeparam>
    public interface IGetPagination<TAggregateRoot>
        where TAggregateRoot : IAggregateRoot
    {
        /// <summary>
        /// Returns a list of paginated roots.
        /// </summary>
        /// <param name="query">A <see cref="PaginationQuery{T}"/> object.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<PaginationResult<TAggregateRoot>> GetPaginatedRoots(PaginationQuery<TAggregateRoot> query, CancellationToken cancellationToken);
    }
}
