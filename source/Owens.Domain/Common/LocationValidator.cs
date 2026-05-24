// <copyright file="LocationValidator.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using FluentValidation;

namespace Owens.Domain.Common
{
    /// <inheritdoc />
    public class LocationValidator : AbstractValidator<Location>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LocationValidator"/> class.
        /// </summary>
        public LocationValidator()
        {
            RuleFor(coordinates => coordinates.Latitude).GreaterThanOrEqualTo(-90).LessThanOrEqualTo(90);
            RuleFor(coordinates => coordinates.Longitude).GreaterThanOrEqualTo(-180).LessThanOrEqualTo(180);
        }
    }
}
