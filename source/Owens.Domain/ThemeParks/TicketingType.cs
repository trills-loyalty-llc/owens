// <copyright file="TicketingType.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

namespace Owens.Domain.ThemeParks
{
    /// <summary>
    /// The type of the ticketed event.
    /// </summary>
    public enum TicketingType
    {
        /// <summary>
        /// A normal everyday ticket.
        /// </summary>
        Normal = 0,

        /// <summary>
        /// A special event closed to the public.
        /// </summary>
        SpecialEvent = 1,

        /// <summary>
        /// A holiday event.
        /// </summary>
        HolidayEvent = 2,

        /// <summary>
        /// Extended hours beyond the normal operating window.
        /// </summary>
        ExtendedHours = 3,
    }
}
