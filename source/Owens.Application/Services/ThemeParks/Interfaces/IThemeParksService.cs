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
        /// Retrieves the status of a theme park and its attractions.
        /// </summary>
        /// <param name="id">An identifier for a theme park.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<ParkStatus> GetThemeParkStatus(Guid id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves the schedule for a theme park.
        /// </summary>
        /// <param name="id">An identifier for a theme park.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<ParkSchedule> GetThemeParkSchedule(Guid id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves all children for a parent theme park.
        /// </summary>
        /// <param name="id">An identifier for a theme park.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<ThemeParkParent> GetThemeParkChildren(Guid id, CancellationToken cancellationToken = default);
    }
}
