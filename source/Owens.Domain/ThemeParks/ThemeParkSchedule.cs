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
        /// <param name="operatingDate">The operating date for the schedule.</param>
        /// <param name="operating">The operation status of the park.</param>
        /// <param name="opening">The opening timestamp for the park.</param>
        /// <param name="closing">The closing timestamp for the park.</param>
        public ThemeParkSchedule(DateOnly operatingDate, OperatingStatus operating, DateTimeOffset opening, DateTimeOffset closing)
        {
            OperatingDate = operatingDate;
            Operating = operating;
            Opening = opening;
            Closing = closing;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ThemeParkSchedule"/> class.
        /// </summary>
        /// <param name="id">The identifier of the park.</param>
        /// <param name="operatingDate">The operating date for the schedule.</param>
        /// <param name="operating">The operation status of the park.</param>
        /// <param name="opening">The opening timestamp for the park.</param>
        /// <param name="closing">The closing timestamp for the park.</param>
        public ThemeParkSchedule(Guid id, DateOnly operatingDate, OperatingStatus operating, DateTimeOffset opening, DateTimeOffset closing)
            : base(id)
        {
            OperatingDate = operatingDate;
            Operating = operating;
            Opening = opening;
            Closing = closing;
        }

        /// <summary>
        /// Gets the operating date.
        /// </summary>
        public DateOnly OperatingDate { get; }

        /// <summary>
        /// Gets get the operating status.
        /// </summary>
        public OperatingStatus Operating { get; }

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
