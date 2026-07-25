// <copyright file="WeatherStatusTypeBuilder.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Owens.Domain.ThemeParks;
using Owens.Infrastructure.DataAccess.Common;

namespace Owens.Infrastructure.DataAccess.ThemeParks
{
    /// <inheritdoc />
    public class WeatherStatusTypeBuilder : EntityTypeConfigurationBase<WeatherStatus>
    {
        /// <inheritdoc/>
        protected override void ConfigureEntity(EntityTypeBuilder<WeatherStatus> builder)
        {
            builder.Property(x => x.TimeStamp);
            builder.Property(x => x.TemperatureFahrenheit);
            builder.Property(x => x.FeelsLikeFahrenheit);
            builder.Property(x => x.HeatIndexFahrenheit);
            builder.Property(x => x.IsDaytime);
            builder.Property(x => x.UltraVioletIndex);
            builder.Property(x => x.Humidity);
            builder.Property(x => x.WindMph);
            builder.Property(x => x.CloudCoverage);
            builder.Property(x => x.WillItRain);
            builder.Property(x => x.ChanceOfRain);
            builder.Property(x => x.InchesOfPrecipitation);
            builder.Property(x => x.Conditions);
            builder.Property(x => x.ConditionsSummary);

            base.ConfigureEntity(builder);
        }
    }
}
