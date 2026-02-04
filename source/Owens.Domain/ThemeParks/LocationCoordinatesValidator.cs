// <copyright file="LocationCoordinatesValidator.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using FluentValidation;

namespace Owens.Domain.ThemeParks
{
    /// <inheritdoc />
    public class LocationCoordinatesValidator : AbstractValidator<LocationCoordinates>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LocationCoordinatesValidator"/> class.
        /// </summary>
        public LocationCoordinatesValidator()
        {
            RuleFor(coordinates => coordinates.Latitude).GreaterThanOrEqualTo(-90).LessThanOrEqualTo(90);
            RuleFor(coordinates => coordinates.Longitude).GreaterThanOrEqualTo(-180).LessThanOrEqualTo(180);
        }
    }
}
