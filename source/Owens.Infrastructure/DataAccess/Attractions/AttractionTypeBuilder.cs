// <copyright file="AttractionTypeBuilder.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Owens.Domain.Attractions;
using Owens.Infrastructure.DataAccess.Common;

namespace Owens.Infrastructure.DataAccess.Attractions
{
    /// <inheritdoc />
    public class AttractionTypeBuilder : AggregateRootConfigurationBase<Attraction>
    {
        /// <inheritdoc/>
        protected override void ConfigureRoot(EntityTypeBuilder<Attraction> builder)
        {
            builder.Property(attraction => attraction.Description);

            builder.HasIndex(attraction => attraction.QueueTimesExternalId).IsUnique();

            builder.HasIndex(attraction => attraction.SchedulingExternalId).IsUnique();

            builder.Property(attraction => attraction.AttractionType);

            builder
                .HasMany(attraction => attraction.Status)
                .WithOne()
                .IsRequired();
        }
    }
}
