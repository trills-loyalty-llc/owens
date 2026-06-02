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
        /// A holiday event specific to Halloween.
        /// </summary>
        HalloweenEvent = 3,

        /// <summary>
        /// A holiday event specific to Christmas.
        /// </summary>
        ChristmasEvent = 4,

        /// <summary>
        /// Extended hours beyond the normal operating window.
        /// </summary>
        ExtendedHours = 5,

        /// <summary>
        /// Early entry hours for hotel guests beyond the normal operating window.
        /// </summary>
        EarlyHotelEntry = 6,

        /// <summary>
        /// Early entry hours for annual passes beyond the normal operating window.
        /// </summary>
        EarlyAnnualPassEntry = 7,

        /// <summary>
        /// The lowest or cheapest annual pass option.
        /// </summary>
        FirstTierAnnualPass = 8,

        /// <summary>
        /// The second tier annual pass option.
        /// </summary>
        SecondTierAnnualPass = 9,

        /// <summary>
        /// The third tier annual pass option.
        /// </summary>
        ThirdTierAnnualPass = 10,

        /// <summary>
        /// The highest or most expensive annual pass option.
        /// </summary>
        FourthTierAnnualPass = 11,
    }
}
