// <copyright file="MemberBuilder.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Owens.Domain.Members;

namespace Owens.Infrastructure.DataAccess.Members
{
    /// <inheritdoc />
    public class MemberBuilder : IEntityTypeConfiguration<Member>
    {
        /// <inheritdoc/>
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.Property(x => x.Id).ValueGeneratedNever();
        }
    }
}
