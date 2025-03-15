﻿// <copyright file="MemberBuilder.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Owens.Domain.Members;
using Owens.Infrastructure.DataAccess.Common;

namespace Owens.Infrastructure.DataAccess.Members
{
    /// <inheritdoc />
    public class MemberBuilder : EntityTypeConfigurationBase<Member>
    {
        /// <inheritdoc />
        protected override void ConfigureRoot(EntityTypeBuilder<Member> builder)
        {
        }
    }
}
