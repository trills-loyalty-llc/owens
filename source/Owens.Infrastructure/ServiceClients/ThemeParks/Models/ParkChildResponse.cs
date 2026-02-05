// <copyright file="ParkChildResponse.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using System.Text.Json.Serialization;
using ClearDomain.GuidPrimary;
using Owens.Domain.Common;

namespace Owens.Infrastructure.ServiceClients.ThemeParks.Models
{
    /// <summary>
    /// Response wrapper for a park child.
    /// </summary>
    public class ParkChildResponse : IEntity, IDescription
    {
        /// <inheritdoc/>
        [JsonPropertyName("id")]
        public Guid Id { get; init; }

        /// <inheritdoc/>
        [JsonPropertyName("name")]
        public string Description { get; init; } = string.Empty;
    }
}
