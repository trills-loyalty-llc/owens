// <copyright file="ScheduleResult.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

namespace Owens.Infrastructure.ServiceClients.ThemeParks.Models.Scheduling
{
    /// <summary>
    /// Schedule data from the external client.
    /// </summary>
    public class ScheduleResult
    {
        /// <summary>
        /// Gets the time zone for the schedule.
        /// </summary>
        public string TimeZone { get; init; } = string.Empty;

        /// <summary>
        /// Gets the ticketing schedule.
        /// </summary>
        public IEnumerable<TicketingScheduleResult> Schedule { get; init; } = Enumerable.Empty<TicketingScheduleResult>();
    }
}
