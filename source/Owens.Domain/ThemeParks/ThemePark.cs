// <copyright file="ThemePark.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using ClearDomain.GuidPrimary;
using Owens.Domain.Common;

namespace Owens.Domain.ThemeParks
{
    /// <summary>
    /// Designates a defined boundary around a series of attraction.
    /// </summary>
    public class ThemePark : AggregateRoot, IDescription
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ThemePark"/> class.
        /// </summary>
        /// <param name="description">An alphaNumeric description for the park.</param>
        /// <param name="coordinates">The coordinates for the park.</param>
        /// <param name="schedulingExternalId">The external identifier for scheduling.</param>
        public ThemePark(string description, LocationCoordinates coordinates, Guid schedulingExternalId)
        {
            Description = description;
            Coordinates = coordinates;
            SchedulingExternalId = schedulingExternalId;
            ParkZones = new List<ParkZone>();
            WeatherStatus = new List<WeatherStatus>();
            Schedules = new List<ThemeParkSchedule>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ThemePark"/> class.
        /// </summary>
        /// <param name="id">The identifier for the park.</param>
        /// <param name="description">An alphaNumeric description for the park.</param>
        /// <param name="schedulingExternalId">The external identifier for scheduling.</param>
        public ThemePark(Guid id, string description, Guid schedulingExternalId)
            : base(id)
        {
            Description = description;
            SchedulingExternalId = schedulingExternalId;
            Coordinates = LocationCoordinates.Empty();
            ParkZones = new List<ParkZone>();
            WeatherStatus = new List<WeatherStatus>();
            Schedules = new List<ThemeParkSchedule>();
        }

        /// <inheritdoc/>
        public string Description { get; }

        /// <summary>
        /// Gets get the external identifier for scheduling.
        /// </summary>
        public Guid SchedulingExternalId { get; }

        /// <summary>
        /// Gets the location coordinates of the park.
        /// </summary>
        public LocationCoordinates Coordinates { get; }

        /// <summary>
        /// Gets the zones available in the park.
        /// </summary>
        public ICollection<ParkZone> ParkZones { get; }

        /// <summary>
        /// Gets the weather status updates for a theme park.
        /// </summary>
        public ICollection<WeatherStatus> WeatherStatus { get; }

        /// <summary>
        /// Gets the schedules for a theme park.
        /// </summary>
        public ICollection<ThemeParkSchedule> Schedules { get; }

        /// <summary>
        /// Appends a weather update to the theme park.
        /// </summary>
        /// <param name="weatherStatus">A weather update to append.</param>
        public void AppendWeather(WeatherStatus weatherStatus)
        {
            WeatherStatus.Add(weatherStatus);
        }
    }
}
