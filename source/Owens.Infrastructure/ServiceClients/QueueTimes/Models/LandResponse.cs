// <copyright file="LandResponse.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using System.Text.Json.Serialization;

namespace Owens.Infrastructure.ServiceClients.QueueTimes.Models
{
    /// <summary>
    /// Wrapper for a land response.
    /// </summary>
    public class LandResponse
    {
        /// <summary>
        /// Gets all rides from the response.
        /// </summary>
        [JsonPropertyName("rides")]
        public IEnumerable<RideResponse> Rides { get; init; } = Enumerable.Empty<RideResponse>();
    }
}
