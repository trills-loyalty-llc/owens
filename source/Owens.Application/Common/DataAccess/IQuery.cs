// <copyright file="IQuery.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using System.Linq.Expressions;
using ClearDomain.GuidPrimary;

namespace Owens.Application.Common.DataAccess
{
    /// <summary>
    /// Base interface for a persistence query.
    /// </summary>
    /// <typeparam name="TAggregateRoot">The type of the root.</typeparam>
    public interface IQuery<TAggregateRoot>
        where TAggregateRoot : IAggregateRoot
    {
        /// <summary>
        /// Gets the query expression.
        /// </summary>
        public Expression<Func<TAggregateRoot, bool>> Query { get; }
    }
}
