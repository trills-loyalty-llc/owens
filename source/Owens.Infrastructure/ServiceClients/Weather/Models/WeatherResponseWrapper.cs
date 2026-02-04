// <copyright file="WeatherResponseWrapper.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using System.Text.Json.Serialization;

namespace Owens.Infrastructure.ServiceClients.Weather.Models
{
    /// <summary>
    /// Response wrapper for weather.
    /// </summary>
    public class WeatherResponseWrapper
    {
        /// <summary>
        /// Gets the current weather response.
        /// </summary>
        [JsonPropertyName("current")]
        public CurrentWeatherResponse Current { get; init; } = new CurrentWeatherResponse();

        /// <summary>
        /// Gets a static empty instance.
        /// </summary>
        /// <returns>An empty <see cref="WeatherResponseWrapper"/> instance.</returns>
        public static WeatherResponseWrapper Default()
        {
            return new WeatherResponseWrapper();
        }
    }
}
