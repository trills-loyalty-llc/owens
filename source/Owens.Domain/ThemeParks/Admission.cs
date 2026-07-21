// <copyright file="Admission.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using ClearDomain.GuidPrimary;

namespace Owens.Domain.ThemeParks
{
    /// <summary>
    /// A schedule.
    /// </summary>
    public class Admission : Entity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Admission"/> class.
        /// </summary>
        /// <param name="opening">The opening timestamp for the park.</param>
        /// <param name="closing">The closing timestamp for the park.</param>
        /// <param name="ticketing">The ticket pricing for the schedule.</param>
        public Admission(DateTimeOffset opening, DateTimeOffset closing, Ticketing ticketing)
        {
            Opening = opening;
            Closing = closing;
            Ticketing = ticketing;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Admission"/> class.
        /// </summary>
        /// <param name="id">The identifier of the park.</param>
        /// <param name="opening">The opening timestamp for the park.</param>
        /// <param name="closing">The closing timestamp for the park.</param>
        public Admission(Guid id, DateTimeOffset opening, DateTimeOffset closing)
            : base(id)
        {
            Opening = opening;
            Closing = closing;
            Ticketing = Ticketing.Empty();
        }

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
