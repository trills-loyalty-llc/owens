// <copyright file="IAddObject.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using Owens.Domain.Common;

namespace Owens.Application.Common.DataAccess
{
    /// <summary>
    /// Interface for adding an object to the persistence.
    /// </summary>
    /// <typeparam name="TAggregateRoot">The type of the aggregate root.</typeparam>
    public interface IAddObject<in TAggregateRoot>
        where TAggregateRoot : IAggregateRoot
    {
        /// <summary>
        /// Adds an object to the persistence.
        /// </summary>
        /// <param name="aggregateRoot">The <see cref="IAggregateRoot"/> object.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<bool> AddObject(TAggregateRoot aggregateRoot, CancellationToken cancellationToken);
    }
}
