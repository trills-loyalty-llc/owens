// <copyright file="AggregateRootConfigurationBase.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using ClearDomain.GuidPrimary;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Owens.Infrastructure.DataAccess.Common
{
    /// <inheritdoc />
    public abstract class AggregateRootConfigurationBase<TRoot> : EntityTypeConfigurationBase<TRoot>
        where TRoot : class, IAggregateRoot
    {
        /// <inheritdoc/>
        protected override void ConfigureEntity(EntityTypeBuilder<TRoot> builder)
        {
            builder.Ignore(root => root.DomainEvents);

            ConfigureRoot(builder);
        }

        /// <summary>
        /// Adds additional aggregate root configurations.
        /// </summary>
        /// <param name="builder">A <see cref="EntityTypeBuilder{TEntity}"/> object.</param>
        protected abstract void ConfigureRoot(EntityTypeBuilder<TRoot> builder);
    }
}
