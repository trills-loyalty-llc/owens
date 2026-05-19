// <copyright file="StandByResult.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using System.Text.Json.Serialization;

namespace Owens.Infrastructure.ServiceClients.ThemeParks.Models
{
    /// <summary>
    /// Stand By data from the external client.
    /// </summary>
    public class StandByResult
    {
        /// <summary>
        /// Gets the current standby wait time in minutes.
        /// </summary>
        [JsonPropertyName("waitTime")]
        public int WaitInMinutes { get; init; }

        /// <summary>
        /// Empty result to satisfy nullable requirements.
        /// </summary>
        /// <returns>An empty <see cref="StandByResult"/> object.</returns>
        public static StandByResult Empty()
        {
            return new StandByResult();
        }
    }
}
