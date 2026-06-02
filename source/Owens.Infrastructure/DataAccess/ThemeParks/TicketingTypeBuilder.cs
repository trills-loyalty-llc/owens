// <copyright file="TicketingTypeBuilder.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Owens.Domain.ThemeParks;
using Owens.Infrastructure.DataAccess.Common;

namespace Owens.Infrastructure.DataAccess.ThemeParks
{
    /// <inheritdoc />
    public class TicketingTypeBuilder : EntityTypeConfigurationBase<Ticketing>
    {
        /// <inheritdoc/>
        protected override void ConfigureEntity(EntityTypeBuilder<Ticketing> builder)
        {
            builder.Property(ticketing => ticketing.Description);

            builder.Property(ticketing => ticketing.Price);

            builder.Property(ticketing => ticketing.TicketingType);

            base.ConfigureEntity(builder);
        }
    }
}
