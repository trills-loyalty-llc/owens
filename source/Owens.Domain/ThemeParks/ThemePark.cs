// <copyright file="ThemePark.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using ClearDomain.GuidPrimary;
using Owens.Domain.Attractions;
using Owens.Domain.Common;

namespace Owens.Domain.ThemeParks
{
    /// <summary>
    /// Designates a defined boundary around a series of attraction.
    /// </summary>
    public class ThemePark : AggregateRoot
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ThemePark"/> class.
        /// </summary>
        /// <param name="id">The park identifier.</param>
        /// <param name="description">An alphaNumeric description for the park.</param>
        /// <param name="externalId">The external identifier of the theme park.</param>
        /// <param name="location">The location for the park.</param>
        public ThemePark(Guid id, string description, int externalId, Location location)
            : base(id)
        {
            Description = description;
            ExternalId = externalId;
            Location = location;
            WeatherStatus = new List<WeatherStatus>();
            Admissions = new List<Admission>();
            Attractions = new List<Attraction>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ThemePark"/> class.
        /// </summary>
        /// <param name="id">The identifier for the park.</param>
        /// <param name="description">An alphaNumeric description for the park.</param>
        /// <param name="externalId">The external identifier of the theme park.</param>
        public ThemePark(Guid id, string description, int externalId)
            : base(id)
        {
            Description = description;
            ExternalId = externalId;
            Location = Location.Empty();
            WeatherStatus = new List<WeatherStatus>();
            Admissions = new List<Admission>();
            Attractions = new List<Attraction>();
        }

        /// <summary>
        /// Gets the theme park description.
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Gets the external id. Used to identify with certain purchases.
        /// </summary>
        public int ExternalId { get; }

        /// <summary>
        /// Gets the location coordinates of the park.
        /// </summary>
        public Location Location { get; }

        /// <summary>
        /// Gets the weather status updates for a theme park.
        /// </summary>
        public ICollection<WeatherStatus> WeatherStatus { get; }

        /// <summary>
        /// Gets the schedules for a theme park.
        /// </summary>
        public ICollection<Admission> Admissions { get; }

        /// <summary>
        /// Gets the attractions for a theme park.
        /// </summary>
        public ICollection<Attraction> Attractions { get; }

        /// <summary>
        /// Appends a weather update to the theme park.
        /// </summary>
        /// <param name="weatherStatus">A weather update to append.</param>
        public void AppendWeather(WeatherStatus weatherStatus)
        {
            WeatherStatus.Add(weatherStatus);
        }

        /// <summary>
        /// Appends a schedule to a theme park.
        /// </summary>
        /// <param name="schedule">A schedule update to append.</param>
        public void AppendSchedule(Admission schedule)
        {
            Admissions.Add(schedule);
        }

        /// <summary>
        /// Appends an attraction to a theme park.
        /// </summary>
        /// <param name="attraction">An attraction to append.</param>
        public void AppendAttraction(Attraction attraction)
        {
            Attractions.Add(attraction);
        }
    }
}
