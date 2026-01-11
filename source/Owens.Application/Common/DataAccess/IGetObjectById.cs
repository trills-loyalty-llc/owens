// <copyright file="IGetObjectById.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using ClearDomain.GuidPrimary;

namespace Owens.Application.Common.DataAccess
{
    /// <summary>
    /// Interface for searching for an object by its identifier.
    /// </summary>
    /// <typeparam name="TAggregateRoot">The type of the aggregate root.</typeparam>
    public interface IGetObjectById<TAggregateRoot>
        where TAggregateRoot : IAggregateRoot
    {
        /// <summary>
        /// Searches for an object by the identifier from the persistence.
        /// </summary>
        /// <param name="id">The <see cref="Guid"/> identifier to search by.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<TAggregateRoot?> GetObjectById(Guid id, CancellationToken cancellationToken);
    }
}
