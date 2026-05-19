// <copyright file="QueueResult.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using System.Text.Json.Serialization;

namespace Owens.Infrastructure.ServiceClients.ThemeParks.Models
{
    /// <summary>
    /// Queue data from the external client.
    /// </summary>
    public class QueueResult
    {
        /// <summary>
        /// Gets the current standby status.
        /// </summary>
        [JsonPropertyName("STANDBY")]
        public StandByResult StandBy { get; init; } = StandByResult.Empty();

        /// <summary>
        /// Empty instance to satisfy nullable requirements.
        /// </summary>
        /// <returns>An empty <see cref="QueueResult"/> object.</returns>
        public static QueueResult Empty()
        {
            return new QueueResult();
        }
    }
}
