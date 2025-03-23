// <copyright file="EntityTypeConfigurationBase.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Owens.Domain.Common;

namespace Owens.Infrastructure.Common.DataAccess
{
    /// <inheritdoc />
    public abstract class EntityTypeConfigurationBase<TRoot> : IEntityTypeConfiguration<TRoot>
        where TRoot : class, IAggregateRoot
    {
        /// <inheritdoc />
        public void Configure(EntityTypeBuilder<TRoot> builder)
        {
            builder.Property(root => root.Id).ValueGeneratedNever();
            builder.Ignore(root => root.DomainEvents);

            ConfigureRoot(builder);
        }

        /// <summary>
        /// Adds additional entity configuration.
        /// </summary>
        /// <param name="builder">A <see cref="EntityTypeBuilder{TEntity}"/> object.</param>
        protected abstract void ConfigureRoot(EntityTypeBuilder<TRoot> builder);
    }
}
