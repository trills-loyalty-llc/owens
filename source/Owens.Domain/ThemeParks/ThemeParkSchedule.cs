// <copyright file="ThemeParkSchedule.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using ClearDomain.GuidPrimary;
using Owens.Domain.Common;

namespace Owens.Domain.ThemeParks
{
    /// <summary>
    /// A schedule.
    /// </summary>
    public class ThemeParkSchedule : Entity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ThemeParkSchedule"/> class.
        /// </summary>
        /// <param name="operating">The operation status of the park.</param>
        /// <param name="opening">The opening timestamp for the park.</param>
        /// <param name="closing">The closing timestamp for the park.</param>
        /// <param name="ticketing">The ticket pricing for the schedule.</param>
        public ThemeParkSchedule(OperatingStatus operating, DateTimeOffset opening, DateTimeOffset closing, Ticketing ticketing)
        {
            Operating = operating;
            Opening = opening;
            Closing = closing;
            Ticketing = ticketing;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ThemeParkSchedule"/> class.
        /// </summary>
        /// <param name="id">The identifier of the park.</param>
        /// <param name="operating">The operation status of the park.</param>
        /// <param name="opening">The opening timestamp for the park.</param>
        /// <param name="closing">The closing timestamp for the park.</param>
        public ThemeParkSchedule(Guid id, OperatingStatus operating, DateTimeOffset opening, DateTimeOffset closing)
            : base(id)
        {
            Operating = operating;
            Opening = opening;
            Closing = closing;
            Ticketing = Ticketing.Empty();
        }

        /// <summary>
        /// Gets get the operating status.
        /// </summary>
        public OperatingStatus Operating { get; }

        /// <summary>
        /// Gets the ticket for the schedule.
        /// </summary>
        public Ticketing Ticketing { get; }

        /// <summary>
        /// Gets the opening time.
        /// </summary>
        public DateTimeOffset Opening { get; }

        /// <summary>
        /// Gets the closing time.
        /// </summary>
        public DateTimeOffset Closing { get; }
    }
}
