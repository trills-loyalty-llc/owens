// <copyright file="LogTypeBuilder.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Owens.Infrastructure.Common.DataAccess;

namespace Owens.Infrastructure.Common.Logging.Common
{
    /// <inheritdoc />
    public class LogTypeBuilder : EntityTypeConfigurationBase<Log>
    {
        /// <inheritdoc/>
        protected override void ConfigureRoot(EntityTypeBuilder<Log> builder)
        {
            builder.Property(log => log.DateTimeOffset);
        }
    }
}
