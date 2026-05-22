// <copyright file="ScheduleResult.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

namespace Owens.Infrastructure.ServiceClients.ThemeParks.Models
{
    /// <summary>
    /// Schedule data from the external client.
    /// </summary>
    public class ScheduleResult
    {
        /// <summary>
        /// Gets the ticketing schedule.
        /// </summary>
        public IEnumerable<TicketingScheduleResult> Schedule { get; init; } = Enumerable.Empty<TicketingScheduleResult>();
    }
}
