// <copyright file="MemberTypeBuilder.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Owens.Domain.Members;
using Owens.Infrastructure.Common.DataAccess;

namespace Owens.Infrastructure.DataAccess.Members
{
    /// <inheritdoc />
    public class MemberTypeBuilder : EntityTypeConfigurationBase<Member>
    {
        /// <inheritdoc />
        protected override void ConfigureRoot(EntityTypeBuilder<Member> builder)
        {
        }
    }
}
