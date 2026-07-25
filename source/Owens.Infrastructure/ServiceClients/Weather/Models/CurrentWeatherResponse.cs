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
        /// Gets the perceived temperature in Fahrenheit.
        /// </summary>
        [JsonPropertyName("feelslike_f")]
        public double FeelsLikeFahrenheit { get; init; }

        /// <summary>
        /// Gets the heat index in Fahrenheit.
        /// </summary>
        [JsonPropertyName("heatindex_f")]
        public double HeatIndexFahrenheit { get; init; }

        /// <summary>
        /// Gets the UV index.
        /// </summary>
        [JsonPropertyName("uv")]
        public double UltraVioletIndex { get; init; }

        /// <summary>
        /// Gets a value indicating whether the sun is visible.
        /// </summary>
        [JsonPropertyName("is_day")]
        public double IsDaylight { get; init; }

        /// <summary>
        /// Gets the current wind in miles per hour.
        /// </summary>
        [JsonPropertyName("wind_mph")]
        public double WindMph { get; init; }

        /// <summary>
        /// Gets the current humidity.
        /// </summary>
        [JsonPropertyName("humidity")]
        public int Humidity { get; init; }

        /// <summary>
        /// Gets the current cloud coverage.
        /// </summary>
        [JsonPropertyName("cloud")]
        public int CloudCoverage { get; init; }

        /// <summary>
        /// Gets a value indicating whether rain is inevitable.
        /// </summary>
        [JsonPropertyName("will_it_rain")]
        public double WillItRain { get; init; }

        /// <summary>
        /// Gets a value indicating whether rain is possible.
        /// </summary>
        [JsonPropertyName("chance_of_rain")]
        public double ChanceOfRain { get; init; }

        /// <summary>
        /// Gets the recent precipitation in inches.
        /// </summary>
        [JsonPropertyName("precip_in")]
        public double PrecipitationInInches { get; init; }

        /// <summary>
        /// Gets the current conditions.
        /// </summary>
        [JsonPropertyName("condition")]
        public ConditionsResponse Conditions { get; init; } = new ConditionsResponse();
    }
}
