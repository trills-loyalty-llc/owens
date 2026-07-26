// <copyright file="ParkSchedule.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

namespace Owens.Application.Services.ThemeParks.Models
{
    /// <summary>
    /// Schedule result for a theme park.
    /// </summary>
    public class ParkSchedule
    {
        /// <summary>
        /// Gets the time zone for the park schedule.
        /// </summary>
        public string TimeZone { get; init; } = string.Empty;

        /// <summary>
        /// Gets all schedules for a theme park.
        /// </summary>
        public IEnumerable<ParkScheduleItem> Schedules { get; init; } = Enumerable.Empty<ParkScheduleItem>();
    }
}
