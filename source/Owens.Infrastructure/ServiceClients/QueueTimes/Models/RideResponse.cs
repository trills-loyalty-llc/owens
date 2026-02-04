// <copyright file="RideResponse.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using System.Text.Json.Serialization;

namespace Owens.Infrastructure.ServiceClients.QueueTimes.Models
{
    /// <summary>
    /// Wrapper for ride response.
    /// </summary>
    public class RideResponse
    {
        /// <summary>
        /// Gets the ride identifier.
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; init; }

        /// <summary>
        /// Gets the ride name.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; init; } = string.Empty;

        /// <summary>
        /// Gets a value indicating whether the ride is open or not.
        /// </summary>
        [JsonPropertyName("is_open")]
        public bool IsOpen { get; init; }

        /// <summary>
        /// Gets the current wait times in whole integer minutes.
        /// </summary>
        [JsonPropertyName("wait_time")]
        public int WaitTime { get; init; }
    }
}
