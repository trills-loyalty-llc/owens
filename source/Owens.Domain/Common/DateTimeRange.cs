// <copyright file="DateTimeRange.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using ClearDomain.Common;

namespace Owens.Domain.Common
{
    /// <summary>
    /// Describes a timestamp as a DateTime, Offset, and TimeZone.
    /// </summary>
    public class DateTimeRange : ValueObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DateTimeRange"/> class.
        /// Assumes a permanent attraction lifecycle.
        /// </summary>
        public DateTimeRange()
        {
            Start = DateTimeOffset.UtcNow;
            End = DateTimeOffset.MaxValue;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DateTimeRange"/> class.
        /// </summary>
        /// <param name="start">A <see cref="DateTimeOffset"/> as the start, always set to UTC.</param>
        /// <param name="end">A <see cref="DateTimeOffset"/> as the end, always set to UTC.</param>
        public DateTimeRange(DateTimeOffset start, DateTimeOffset end)
        {
            Start = start;
            End = end;
        }

        /// <summary>
        /// Gets the start date time offset. Always in UTC.
        /// </summary>
        public DateTimeOffset Start { get; }

        /// <summary>
        /// Gets the end date time offset. Always in UTC.
        /// </summary>
        public DateTimeOffset End { get; }

        /// <summary>
        /// Returns an empty instance to satisfy nullable requirements.
        /// </summary>
        /// <returns>A <see cref="DateTimeRange"/> instance.</returns>
        public static DateTimeRange Empty()
        {
            return new DateTimeRange(DateTimeOffset.MinValue, DateTimeOffset.MinValue);
        }
    }
}
