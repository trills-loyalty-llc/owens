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
            builder
                .HasMany(themePark => themePark.ParkZones)
                .WithOne()
                .IsRequired();
        }
    }
}
