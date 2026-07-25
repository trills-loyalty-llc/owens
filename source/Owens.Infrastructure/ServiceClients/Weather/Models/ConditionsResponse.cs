// <copyright file="ConditionsResponse.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using Owens.Domain.ThemeParks;
using System.Text.Json.Serialization;

namespace Owens.Infrastructure.ServiceClients.Weather.Models
{
    /// <summary>
    /// Response wrapper for the current conditions.
    /// </summary>
    public class ConditionsResponse
    {
        /// <summary>
        /// Gets a brief description of the current conditions.
        /// </summary>
        [JsonPropertyName("text")]
        public string Description { get; init; } = string.Empty;

        /// <summary>
        /// Gets the conditions code.
        /// </summary>
        [JsonPropertyName("code")]
        public WeatherConditions ConditionsCode { get; init; }
    }
}
