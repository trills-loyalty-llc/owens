// <copyright file="Destination.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using ClearDomain.GuidPrimary;
using Owens.Domain.Common;

namespace Owens.Application.Services.ThemeParks.Models
{
    /// <summary>
    /// Synonymous with a resort area. Data structure comes for the external client.
    /// </summary>
    public class Destination : IEntity, IDescription
    {
        /// <inheritdoc/>
        public Guid Id { get; init; }

        /// <inheritdoc/>
        public string Description { get; init; } = string.Empty;

        /// <summary>
        /// Gets all destination parks.
        /// </summary>
        public IEnumerable<DestinationPark> Parks { get; init; } = Enumerable.Empty<DestinationPark>();
    }
}
