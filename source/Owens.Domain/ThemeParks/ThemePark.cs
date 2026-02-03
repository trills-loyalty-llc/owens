// <copyright file="ThemePark.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using ClearDomain.GuidPrimary;

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
        public ThemePark()
        {
            ParkZones = new List<ParkZone>();
        }

        /// <summary>
        /// Gets the zones available in the park.
        /// </summary>
        public ICollection<ParkZone> ParkZones { get; }
    }
}
