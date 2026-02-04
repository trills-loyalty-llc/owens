// <copyright file="IWeatherService.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using Owens.Application.Services.Weather.Models;
using Owens.Domain.ThemeParks;

namespace Owens.Application.Services.Weather.Interfaces
{
    /// <summary>
    /// A client to query for weather.
    /// </summary>
    public interface IWeatherService
    {
        /// <summary>
        /// Retrieves weather at a location.
        /// </summary>
        /// <param name="coordinates">A <see cref="LocationCoordinates"/> instance.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<CurrentWeather> GetWeatherAtLocation(LocationCoordinates coordinates, CancellationToken cancellationToken = default);
    }
}
