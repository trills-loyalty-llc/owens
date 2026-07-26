// <copyright file="ParkScheduleItem.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

namespace Owens.Application.Services.ThemeParks.Models
{
    /// <summary>
    /// A segment of a park schedule that typically translates to a ticket.
    /// </summary>
    public class ParkScheduleItem
    {
        /// <summary>
        /// Gets the date of the schedule item.
        /// </summary>
        public DateOnly Date { get; init; }

        /// <summary>
        /// Gets the ticketing type.
        /// </summary>
        public string Type { get; init; } = string.Empty;

        /// <summary>
        /// Gets the closing time for the schedule item.
        /// </summary>
        public DateTimeOffset ClosingTime { get; init; }

        /// <summary>
        /// Gets the opening time of the schedule item.
        /// </summary>
        public DateTimeOffset OpeningTime { get; init; }

        /// <summary>
        /// Gets a description on the schedule item.
        /// </summary>
        public string Description { get; init; } = string.Empty;

        /// <summary>
        /// Gets all available purchases for a schedule.
        /// </summary>
        public IEnumerable<ParkSchedulePurchase> Purchases { get; init; } = Enumerable.Empty<ParkSchedulePurchase>();
    }
}
