// <copyright file="Member.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using Owens.Domain.Common;

namespace Owens.Domain.Members
{
    /// <inheritdoc />
    public class Member : AggregateRoot
    {
        /// <inheritdoc />
        public Member()
        {
        }

        /// <inheritdoc />
        public Member(Guid id)
            : base(id)
        {
        }
    }
}
