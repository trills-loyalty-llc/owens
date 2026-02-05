// <copyright file="AttractionStatusTypeBuilder.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Owens.Domain.Attractions;
using Owens.Infrastructure.DataAccess.Common;

namespace Owens.Infrastructure.DataAccess.Attractions
{
    /// <inheritdoc />
    public class AttractionStatusTypeBuilder : EntityTypeConfigurationBase<QueueStatus>
    {
        /// <inheritdoc/>
        protected override void ConfigureEntity(EntityTypeBuilder<QueueStatus> builder)
        {
            builder.Property(status => status.Wait);
            builder.Property(status => status.TimeStamp);
            builder.Property(status => status.IsOperational);
        }
    }
}
