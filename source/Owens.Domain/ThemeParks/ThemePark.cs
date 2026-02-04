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
        public ThemePark(string description)
        {
            Description = description;
            Coordinates = LocationCoordinates.Empty();
            ParkZones = new List<ParkZone>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ThemePark"/> class.
        /// </summary>
        /// <param name="id">The identifier for the park.</param>
        /// <param name="description">An alphaNumeric description for the park.</param>
        public ThemePark(Guid id, string description)
            : base(id)
        {
            Description = description;
            Coordinates = LocationCoordinates.Empty();
            ParkZones = new List<ParkZone>();
        }

        /// <inheritdoc/>
        public string Description { get; }

        /// <summary>
        /// Gets the location coordinates of the park.
        /// </summary>
        public LocationCoordinates Coordinates { get; }

        /// <summary>
        /// Gets the zones available in the park.
        /// </summary>
        public ICollection<ParkZone> ParkZones { get; }
    }
}
