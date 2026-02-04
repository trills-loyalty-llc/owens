// <copyright file="IAttractionRepository.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using Owens.Application.Common.DataAccess;
using Owens.Domain.Attractions;

namespace Owens.Application.Attractions.Common
{
    /// <summary>
    /// Interface for interacting with <see cref="Attraction"/> persistence.
    /// </summary>
    public interface IAttractionRepository :
        IAddObject<Attraction>,
        IUpdateObject<Attraction>,
        IGetObjectById<Attraction>
    {
        /// <summary>
        /// Gets the attraction external identifier.
        /// </summary>
        /// <param name="id">The external identifier.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<Attraction?> GetByExternalId(int id, CancellationToken cancellationToken = default);
    }
}
