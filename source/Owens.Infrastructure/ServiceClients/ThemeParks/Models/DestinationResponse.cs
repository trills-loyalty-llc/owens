// <copyright file="DestinationResponse.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using System.Text.Json.Serialization;
using ClearDomain.GuidPrimary;
using Owens.Domain.Common;

namespace Owens.Infrastructure.ServiceClients.ThemeParks.Models
{
    /// <summary>
    /// Wrapper response for destinations.
    /// </summary>
    public class DestinationResponse : IEntity, IDescription
    {
        /// <inheritdoc/>
        [JsonPropertyName("id")]
        public Guid Id { get; init; }

        /// <inheritdoc/>
        [JsonPropertyName("name")]
        public string Description { get; init; } = string.Empty;

        /// <summary>
        /// Gets all park responses.
        /// </summary>
        [JsonPropertyName("parks")]
        public IEnumerable<ParkResponse> Parks { get; init; } = Enumerable.Empty<ParkResponse>();
    }
}
