// <copyright file="IThemeParksService.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using Owens.Domain.Attractions;

namespace Owens.Application.Services.ThemeParks.Interfaces
{
    /// <summary>
    /// A client to query for theme park information.
    /// </summary>
    public interface IThemeParksService
    {
        /// <summary>
        /// Retrieves the current status of an attraction queue.
        /// </summary>
        /// <param name="id">The identifier of teh attraction.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<QueueStatus> GetCurrentStatus(Guid id, CancellationToken cancellationToken = default);
    }
}
