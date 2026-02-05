// <copyright file="LocationResponse.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using System.Text.Json.Serialization;

namespace Owens.Infrastructure.ServiceClients.ThemeParks.Models
{
    /// <summary>
    /// Location response for park locations.
    /// </summary>
    public class LocationResponse
    {
        /// <summary>
        /// Gets the latitude.
        /// </summary>
        [JsonPropertyName("latitude")]
        public double Latitude { get; init; }

        /// <summary>
        /// Gets the longitude.
        /// </summary>
        [JsonPropertyName("longitude")]
        public double Longitude { get; init; }
    }
}
