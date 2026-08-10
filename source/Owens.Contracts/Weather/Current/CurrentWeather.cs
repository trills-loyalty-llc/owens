// <copyright file="CurrentWeather.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using System.Text.Json.Serialization;

namespace Owens.Contracts.Weather.Current
{
    /// <summary>
    /// The current weather response at a given location.
    /// </summary>
    public class CurrentWeather
    {
        /// <summary>
        /// Gets the current temperature on Fahrenheit.
        /// </summary>
        [JsonPropertyName("temp_f")]
        public double TemperatureFahrenheit { get; init; }

        /// <summary>
        /// Gets a value indicating if the sun is visible in the horizon.
        /// </summary>
        [JsonPropertyName("is_day")]
        public int IsDay { get; init; }

        /// <summary>
        /// Gets the current conditions response.
        /// </summary>
        [JsonPropertyName("condition")]
        public CurrentWeatherCondition Condition { get; init; } = new CurrentWeatherCondition();
    }
}
