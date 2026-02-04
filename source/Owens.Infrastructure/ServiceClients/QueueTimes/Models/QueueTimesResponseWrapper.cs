// <copyright file="QueueTimesResponseWrapper.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using System.Text.Json.Serialization;

namespace Owens.Infrastructure.ServiceClients.QueueTimes.Models
{
    /// <summary>
    /// Response wrapper for queues.
    /// </summary>
    public class QueueTimesResponseWrapper
    {
        /// <summary>
        /// Gets all lands objects from the response.
        /// </summary>
        [JsonPropertyName("lands")]
        public IEnumerable<LandResponse> Lands { get; init; } = Enumerable.Empty<LandResponse>();

        /// <summary>
        /// Gets a static empty instance.
        /// </summary>
        /// <returns>An empty <see cref="QueueTimesResponseWrapper"/> instance.</returns>
        public static QueueTimesResponseWrapper Default()
        {
            return new QueueTimesResponseWrapper();
        }
    }
}
