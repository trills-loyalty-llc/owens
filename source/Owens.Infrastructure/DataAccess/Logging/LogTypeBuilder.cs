// <copyright file="LogTypeBuilder.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Owens.Infrastructure.DataAccess.Common;
using Owens.Infrastructure.Logging.Common;

namespace Owens.Infrastructure.DataAccess.Logging
{
    /// <inheritdoc />
    public class LogTypeBuilder : AggregateRootConfigurationBase<Log>
    {
        /// <inheritdoc/>
        protected override void ConfigureRoot(EntityTypeBuilder<Log> builder)
        {
            builder.Property(log => log.DateTimeOffset);
        }
    }
}
