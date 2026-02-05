// <copyright file="IThemeParksService.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using Owens.Application.Services.ThemeParks.Models;

namespace Owens.Application.Services.ThemeParks.Interfaces
{
    /// <summary>
    /// A client to query for theme park information.
    /// </summary>
    public interface IThemeParksService
    {
        /// <summary>
        /// Retrieves all available destinations.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<List<Destination>> GetDestinations(CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves details about a park.
        /// </summary>
        /// <param name="id">The park identifier.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<ParkDetails> GetParkDetails(Guid id, CancellationToken cancellationToken = default);
    }
}
