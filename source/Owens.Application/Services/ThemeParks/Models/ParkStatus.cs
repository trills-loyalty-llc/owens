// <copyright file="ParkStatus.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using Owens.Domain.Attractions;

namespace Owens.Application.Services.ThemeParks.Models
{
    /// <summary>
    /// Status result for a theme park.
    /// </summary>
    public class ParkStatus
    {
        /// <summary>
        /// Gets all attraction status results.
        /// </summary>
        public IEnumerable<(Guid Id, QueueStatus QueueStatus)> Attractions { get; init; } = Enumerable.Empty<(Guid Id, QueueStatus QueueStatus)>();
    }
}
