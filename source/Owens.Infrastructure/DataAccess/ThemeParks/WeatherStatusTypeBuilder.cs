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
            builder.Property(weatherStatus => weatherStatus.TimeStamp);

            builder.Property(weatherStatus => weatherStatus.WindMph);

            builder.Property(weatherStatus => weatherStatus.Conditions);
        }
    }
}
