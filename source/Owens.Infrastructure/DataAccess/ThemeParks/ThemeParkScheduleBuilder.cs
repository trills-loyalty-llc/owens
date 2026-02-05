// <copyright file="ThemeParkScheduleBuilder.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Owens.Domain.ThemeParks;
using Owens.Infrastructure.DataAccess.Common;

namespace Owens.Infrastructure.DataAccess.ThemeParks
{
    /// <inheritdoc />
    public class ThemeParkScheduleBuilder : EntityTypeConfigurationBase<ThemeParkSchedule>
    {
        /// <inheritdoc/>
        protected override void ConfigureEntity(EntityTypeBuilder<ThemeParkSchedule> builder)
        {
            builder.Property(parkSchedule => parkSchedule.OperatingDate);

            builder.Property(parkSchedule => parkSchedule.Operating);

            builder.Property(parkSchedule => parkSchedule.Opening);

            builder.Property(parkSchedule => parkSchedule.Closing);
        }
    }
}
