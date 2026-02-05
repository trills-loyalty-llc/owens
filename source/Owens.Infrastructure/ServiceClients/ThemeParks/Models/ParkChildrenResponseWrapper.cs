// <copyright file="ParkChildrenResponseWrapper.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using System.Text.Json.Serialization;

namespace Owens.Infrastructure.ServiceClients.ThemeParks.Models
{
    /// <summary>
    /// Response wrapper for park children.
    /// </summary>
    public class ParkChildrenResponseWrapper
    {
        /// <summary>
        /// Gets all children of a park.
        /// </summary>
        [JsonPropertyName("children")]
        public IEnumerable<ParkChildResponse> Children { get; init; } = Enumerable.Empty<ParkChildResponse>();

        /// <summary>
        /// An empty response to satisfy nullable requirements.
        /// </summary>
        /// <returns>A <see cref="ParkChildrenResponseWrapper"/> instance.</returns>
        public static ParkChildrenResponseWrapper Default()
        {
            return new ParkChildrenResponseWrapper();
        }
    }
}
