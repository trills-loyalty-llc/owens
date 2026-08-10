// <copyright file="CurrentWeatherWrapper.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using System.Text.Json.Serialization;

namespace Owens.Contracts.Weather.Current
{
    /// <summary>
    /// The response wrapper for the current weather request.
    /// </summary>
    public class CurrentWeatherWrapper
    {
        /// <summary>
        /// Gets the current weather response.
        /// </summary>
        [JsonPropertyName("current")]
        public CurrentWeather Current { get; init; } = new CurrentWeather();
    }
}
