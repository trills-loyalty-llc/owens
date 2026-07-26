// <copyright file="TicketingScheduleResult.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

namespace Owens.Infrastructure.ServiceClients.ThemeParks.Models.Scheduling
{
    /// <summary>
    /// Ticketing schedule from the external client.
    /// </summary>
    public class TicketingScheduleResult
    {
        /// <summary>
        /// Gets the date for the ticket schedule.
        /// </summary>
        public DateOnly Date { get; init; }

        /// <summary>
        /// Gets the ticket type. Translates to an enum in our domain.
        /// </summary>
        public string Type { get; init; } = string.Empty;

        /// <summary>
        /// Gets the description for the ticket. Translates to an enum in our domain.
        /// </summary>
        public string Description { get; init; } = string.Empty;

        /// <summary>
        /// Gets the opening time for the ticket schedule.
        /// </summary>
        public DateTimeOffset OpeningTime { get; init; }

        /// <summary>
        /// Gets the closing time for the ticket schedule.
        /// </summary>
        public DateTimeOffset ClosingTime { get; init; }

        /// <summary>
        /// Gets the purchases for a park schedule.
        /// </summary>
        public IEnumerable<SchedulePurchasesResult> Purchases { get; init; } = Enumerable.Empty<SchedulePurchasesResult>();
    }
}
