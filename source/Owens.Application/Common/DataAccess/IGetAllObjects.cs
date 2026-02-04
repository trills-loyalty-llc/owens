// <copyright file="IGetAllObjects.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using ClearDomain.GuidPrimary;

namespace Owens.Application.Common.DataAccess
{
    /// <summary>
    /// Interface for returning all available objects.
    /// </summary>
    /// <typeparam name="TRoot">The type of the aggregate root.</typeparam>
    public interface IGetAllObjects<TRoot>
        where TRoot : IAggregateRoot
    {
        /// <summary>
        /// Returns all available objects of a specified type.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<List<TRoot>> GetAllObjects(CancellationToken cancellationToken = default);
    }
}
