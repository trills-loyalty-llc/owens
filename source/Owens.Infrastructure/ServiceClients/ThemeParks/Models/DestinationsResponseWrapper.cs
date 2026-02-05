// <copyright file="DestinationsResponseWrapper.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using System.Text.Json.Serialization;

namespace Owens.Infrastructure.ServiceClients.ThemeParks.Models
{
    /// <summary>
    /// Wrapper for a destinations response.
    /// </summary>
    public class DestinationsResponseWrapper
    {
        /// <summary>
        /// Gets all destinations.
        /// </summary>
        [JsonPropertyName("destinations")]
        public IEnumerable<DestinationResponse> Destinations { get; init; } = Enumerable.Empty<DestinationResponse>();

        /// <summary>
        /// Returns an empty response to satisfy nullable requirements.
        /// </summary>
        /// <returns>An empty wrapper response.</returns>
        public static DestinationsResponseWrapper Default()
        {
            return new DestinationsResponseWrapper();
        }
    }
}
