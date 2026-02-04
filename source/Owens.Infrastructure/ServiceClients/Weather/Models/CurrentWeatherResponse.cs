// <copyright file="CurrentWeatherResponse.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using System.Text.Json.Serialization;

namespace Owens.Infrastructure.ServiceClients.Weather.Models
{
    /// <summary>
    /// Response wrapper for the current weather.
    /// </summary>
    public class CurrentWeatherResponse
    {
        /// <summary>
        /// Gets the current temperature in Fahrenheit.
        /// </summary>
        [JsonPropertyName("temp_f")]
        public double TemperatureFahrenheit { get; init; }

        /// <summary>
        /// Gets the current wind in miles per hour.
        /// </summary>
        [JsonPropertyName("wind_mph")]
        public double WindMph { get; init; }

        /// <summary>
        /// Gets the current conditions.
        /// </summary>
        [JsonPropertyName("condition")]
        public ConditionsResponse Conditions { get; init; } = new ConditionsResponse();
    }
}
