// <copyright file="IAggregateRoot.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using ClearDomain.Common;
using MediatR;

namespace Owens.Domain.Common
{
    /// <summary>
    /// Base interface for all aggregate roots.
    /// </summary>
    public interface IAggregateRoot : IAggregateRoot<Guid, INotification>
    {
    }
}
