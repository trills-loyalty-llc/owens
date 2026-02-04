// <copyright file="LocationCoordinates.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using ClearDomain.Common;
using FluentValidation;

namespace Owens.Domain.ThemeParks
{
    /// <summary>
    /// Denotes a location using latitude and longitude.
    /// </summary>
    public class LocationCoordinates : ValueObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LocationCoordinates"/> class.
        /// </summary>
        /// <param name="latitude">A latitude value of a location.</param>
        /// <param name="longitude">A longitude value of a location.</param>
        public LocationCoordinates(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;

            new LocationCoordinatesValidator().ValidateAndThrow(this);
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
        /// <returns>A <see cref="LocationCoordinates"/> instance.</returns>
        public static LocationCoordinates FromCoordinates(double latitude, double longitude)
        {
            return new LocationCoordinates(latitude, longitude);
        }

        /// <summary>
        /// Yield an empty instance to satisfy nullable requirements.
        /// </summary>
        /// <returns>An empty <see cref="LocationCoordinates"/> instance.</returns>
        public static LocationCoordinates Empty()
        {
            return new LocationCoordinates(0, 0);
        }
    }
}
