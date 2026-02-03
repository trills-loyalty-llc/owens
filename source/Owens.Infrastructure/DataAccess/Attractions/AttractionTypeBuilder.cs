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
            builder
                .HasMany(attraction => attraction.Status)
                .WithOne()
                .IsRequired();
        }
    }
}
