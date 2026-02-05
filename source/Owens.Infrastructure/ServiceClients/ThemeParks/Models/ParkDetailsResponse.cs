// <copyright file="ParkDetailsResponse.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using System.Text.Json.Serialization;

namespace Owens.Infrastructure.ServiceClients.ThemeParks.Models
{
    /// <summary>
    /// Wrapper response for park details.
    /// </summary>
    public class ParkDetailsResponse
    {
        /// <summary>
        /// Gets the park timeZone.
        /// </summary>
        [JsonPropertyName("timezone")]
        public string TimeZone { get; init; } = string.Empty;

        /// <summary>
        /// Gets the park location.
        /// </summary>
        [JsonPropertyName("location")]
        public LocationResponse Location { get; init; } = new LocationResponse();

        /// <summary>
        /// Empty response to satisfy nullable requirements.
        /// </summary>
        /// <returns>An empty <see cref="ParkDetailsResponse"/>.</returns>
        public static ParkDetailsResponse Default()
        {
            return new ParkDetailsResponse();
        }
    }
}
