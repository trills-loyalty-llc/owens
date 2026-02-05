// <copyright file="OperatorTypeBuilder.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Owens.Domain.Operators;
using Owens.Infrastructure.DataAccess.Common;

namespace Owens.Infrastructure.DataAccess.Operators
{
    /// <inheritdoc />
    public class OperatorTypeBuilder : AggregateRootConfigurationBase<ResortOperator>
    {
        /// <inheritdoc/>
        protected override void ConfigureRoot(EntityTypeBuilder<ResortOperator> builder)
        {
            builder.Property(resortOperator => resortOperator.Description);

            builder
                .HasMany(resortOperator => resortOperator.ResortAreas)
                .WithOne()
                .IsRequired();

            builder.HasData(new List<ResortOperator>
            {
                new ResortOperator("Disney"),
                new ResortOperator("Universal"),
                new ResortOperator("SeaWorld"),
            });
        }
    }
}
