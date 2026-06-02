// <copyright file="AdmissionTypeBuilder.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Owens.Domain.ThemeParks;
using Owens.Infrastructure.DataAccess.Common;

namespace Owens.Infrastructure.DataAccess.ThemeParks
{
    /// <inheritdoc />
    public class AdmissionTypeBuilder : EntityTypeConfigurationBase<Admission>
    {
        /// <inheritdoc/>
        protected override void ConfigureEntity(EntityTypeBuilder<Admission> builder)
        {
            builder.Property(parkSchedule => parkSchedule.Opening);

            builder.Property(parkSchedule => parkSchedule.Closing);

            builder
                .HasOne(admission => admission.Ticketing)
                .WithMany()
                .IsRequired();
        }
    }
}
