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

            builder.Property(themePark => themePark.ExternalId);

            builder.ComplexProperty(themePark => themePark.Location, propertyBuilder =>
            {
                propertyBuilder.Property(location => location.Latitude);
                propertyBuilder.Property(location => location.Longitude);
            });

            builder
                .HasMany(themePark => themePark.WeatherStatus)
                .WithOne()
                .IsRequired();

            builder
                .HasMany(themePark => themePark.Admissions)
                .WithOne()
                .IsRequired();

            builder
                .HasMany(themePark => themePark.Attractions)
                .WithOne()
                .IsRequired();
        }
    }
}
