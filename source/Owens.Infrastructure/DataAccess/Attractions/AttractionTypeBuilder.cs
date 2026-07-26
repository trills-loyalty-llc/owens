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
            builder.Property(attraction => attraction.ExternalId);

            builder.Property(attraction => attraction.Description);

            builder.Property(attraction => attraction.HeightRequirementInInches);

            builder.Property(attraction => attraction.AttractionType);

            builder.ComplexProperty(attraction => attraction.Location, propertyBuilder =>
            {
                propertyBuilder.Property(location => location.Latitude);
                propertyBuilder.Property(location => location.Longitude);
            });

            builder.ComplexProperty(attraction => attraction.DateTimeRange, propertyBuilder =>
            {
                propertyBuilder.Property(dateTimeRange => dateTimeRange.Start);
                propertyBuilder.Property(dateTimeRange => dateTimeRange.End);
            });

            builder
                .HasMany(attraction => attraction.Status)
                .WithOne()
                .IsRequired();
        }
    }
}
