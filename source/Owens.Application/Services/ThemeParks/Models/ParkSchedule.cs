// <copyright file="ParkSchedule.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using Owens.Domain.ThemeParks;

namespace Owens.Application.Services.ThemeParks.Models
{
    /// <summary>
    /// Schedule result for a theme park.
    /// </summary>
    public class ParkSchedule
    {
        /// <summary>
        /// Gets all schedules for a theme park.
        /// </summary>
        public IEnumerable<Admission> Schedules { get; init; } = Enumerable.Empty<Admission>();
    }
}
