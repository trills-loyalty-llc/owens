// <copyright file="TimeStamp.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using NodaTime;

namespace Owens.Domain.Common
{
    /// <summary>
    /// Describes a timestamp as a DateTime, Offset, and TimeZone.
    /// </summary>
    public class TimeStamp
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TimeStamp"/> class.
        /// </summary>
        /// <param name="dateTimeOffset">A DateTime and its offset.</param>
        /// <param name="timeZoneId">The identifier of a time zone.</param>
        public TimeStamp(DateTimeOffset dateTimeOffset, string timeZoneId)
        {
            DateTimeOffset = dateTimeOffset;
            TimeZoneId = timeZoneId;
        }

        /// <summary>
        /// Gets the date time offset. Always in UTC.
        /// </summary>
        public DateTimeOffset DateTimeOffset { get; }

        /// <summary>
        /// Gets the time zone identifier.
        /// </summary>
        public string TimeZoneId { get; }

        /// <summary>
        /// Returns the time stamp as a ZonedDateTime.
        /// </summary>
        /// <returns>A <see cref="ZonedDateTime"/>.</returns>
        public ZonedDateTime AsDateTimeZone()
        {
            return new ZonedDateTime(Instant.FromDateTimeOffset(DateTimeOffset), DateTimeZoneProviders.Tzdb[TimeZoneId]);
        }
    }
}
