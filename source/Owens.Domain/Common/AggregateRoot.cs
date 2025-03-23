// <copyright file="AggregateRoot.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using ClearDomain.Common;
using MediatR;

namespace Owens.Domain.Common
{
    /// <inheritdoc cref="IAggregateRoot" />
    public abstract class AggregateRoot : AggregateRoot<Guid, INotification>, IAggregateRoot
    {
        /// <inheritdoc />
        protected AggregateRoot()
            : base(Guid.NewGuid())
        {
        }

        /// <inheritdoc />
        protected AggregateRoot(Guid id)
            : base(id)
        {
        }
    }
}
