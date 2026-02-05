// <copyright file="ThemeParkTypeBuilder.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Owens.Domain.ThemeParks;
using Owens.Infrastructure.DataAccess.Common;

namespace Owens.Infrastructure.DataAccess.ThemeParks
{
    /// <inheritdoc />
    public class ThemeParkTypeBuilder : AggregateRootConfigurationBase<ThemePark>
    {
        /// <inheritdoc/>
        protected override void ConfigureRoot(EntityTypeBuilder<ThemePark> builder)
        {
            builder.Property(themePark => themePark.Description);

            builder.Property(themePark => themePark.TimeZoneId);

            builder.ComplexProperty(themePark => themePark.Coordinates, propertyBuilder =>
            {
                propertyBuilder.Property(coordinates => coordinates.Latitude);
                propertyBuilder.Property(coordinates => coordinates.Longitude);
            });

            builder
                .HasMany(themePark => themePark.WeatherStatus)
                .WithOne()
                .IsRequired();

            builder
                .HasMany(themePark => themePark.Schedules)
                .WithOne()
                .IsRequired();
        }
    }
}
