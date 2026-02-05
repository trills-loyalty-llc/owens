// <copyright file="ResortAreaTypeBuilder.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Owens.Domain.Operators;
using Owens.Infrastructure.DataAccess.Common;

namespace Owens.Infrastructure.DataAccess.Operators
{
    /// <inheritdoc />
    public class ResortAreaTypeBuilder : EntityTypeConfigurationBase<ResortArea>
    {
        /// <inheritdoc/>
        protected override void ConfigureEntity(EntityTypeBuilder<ResortArea> builder)
        {
            builder.Property(resortArea => resortArea.Description);
        }
    }
}
