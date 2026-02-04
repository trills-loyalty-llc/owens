// <copyright file="WeatherStatus.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using ClearDomain.GuidPrimary;

namespace Owens.Domain.ThemeParks
{
    /// <summary>
    /// Denotes the weather at a particular location and time.
    /// </summary>
    public class WeatherStatus : Entity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WeatherStatus"/> class.
        /// </summary>
        /// <param name="timeStamp">The timestamp of the status update.</param>
        /// <param name="windMph">The wind in miles per hours.</param>
        /// <param name="conditions">A brief description of the weather.</param>
        public WeatherStatus(DateTimeOffset timeStamp, double windMph, string conditions)
        {
            TimeStamp = timeStamp;
            WindMph = windMph;
            Conditions = conditions;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WeatherStatus"/> class.
        /// </summary>
        /// <param name="id">The identifier for the entity.</param>
        /// <param name="timeStamp">The timestamp of the status update.</param>
        /// <param name="windMph">The wind in miles per hours.</param>
        /// <param name="conditions">A brief description of the weather.</param>
        public WeatherStatus(Guid id, DateTimeOffset timeStamp, double windMph, string conditions)
            : base(id)
        {
            TimeStamp = timeStamp;
            WindMph = windMph;
            Conditions = conditions;
        }

        /// <summary>
        /// Gets the timestamp for the status update. Always in UTC.
        /// </summary>
        public DateTimeOffset TimeStamp { get; }

        /// <summary>
        /// Gets the wind in miles per hour.
        /// </summary>
        public double WindMph { get; }

        /// <summary>
        /// Gets a summary of the current conditions.
        /// </summary>
        public string Conditions { get; }
    }
}
