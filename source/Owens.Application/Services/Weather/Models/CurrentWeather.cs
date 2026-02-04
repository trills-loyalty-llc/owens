// <copyright file="CurrentWeather.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

namespace Owens.Application.Services.Weather.Models
{
    /// <summary>
    /// The result object for a weather update.
    /// </summary>
    public class CurrentWeather
    {
        /// <summary>
        /// Gets the temperature in Fahrenheit.
        /// </summary>
        public double TemperatureFahrenheit { get; init; }

        /// <summary>
        /// Gets the wind in miles per hour.
        /// </summary>
        public double WindMph { get; init; }

        /// <summary>
        /// Gets the current conditions.
        /// </summary>
        public string Conditions { get; init; } = string.Empty;

        /// <summary>
        /// Gets the code for the current conditions.
        /// </summary>
        public int ConditionsCode { get; init; }
    }
}
