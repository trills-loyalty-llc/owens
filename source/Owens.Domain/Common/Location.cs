// <copyright file="Location.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using ClearDomain.Common;
using FluentValidation;

namespace Owens.Domain.Common
{
    /// <summary>
    /// Denotes a location using latitude and longitude.
    /// </summary>
    public class Location : ValueObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Location"/> class.
        /// </summary>
        /// <param name="latitude">A latitude value of a location.</param>
        /// <param name="longitude">A longitude value of a location.</param>
        public Location(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;

            new LocationValidator().ValidateAndThrow(this);
        }

        /// <summary>
        /// Gets the latitude.
        /// </summary>
        public double Latitude { get; }

        /// <summary>
        /// Gets the longitude.
        /// </summary>
        public double Longitude { get; }

        /// <summary>
        /// Creates a location instance from a series of values.
        /// </summary>
        /// <param name="latitude">A latitude value of a location.</param>
        /// <param name="longitude">A longitude value of a location.</param>
        /// <returns>A <see cref="Location"/> instance.</returns>
        public static Location FromMetadata(double latitude, double longitude)
        {
            return new Location(latitude, longitude);
        }

        /// <summary>
        /// Creates an empty location coordinates to satisfy nullable requirements.
        /// </summary>
        /// <returns>An empty <see cref="Location"/>.</returns>
        public static Location Empty()
        {
            return new Location(0, 0);
        }
    }
}
