// <copyright file="PaginationQuery.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using System.Linq.Expressions;
using Owens.Application.Common.Contracts;
using Owens.Domain.Common;

namespace Owens.Application.Common.DataAccess
{
    /// <inheritdoc cref="IQuery{TAggregateRoot}" />
    public class PaginationQuery<TAggregateRoot> : IPagination, IQuery<TAggregateRoot>
        where TAggregateRoot : IAggregateRoot
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PaginationQuery{TAggregateRoot}"/> class.
        /// </summary>
        /// <param name="pagination">An instance of the <see cref="IPagination"/> interface.</param>
        /// <param name="query">A query to execute.</param>
        public PaginationQuery(IPagination pagination, Expression<Func<TAggregateRoot, bool>> query)
        {
            Skip = pagination.Skip;
            Take = pagination.Take;
            Query = query;
        }

        /// <inheritdoc />
        public int Skip { get; }

        /// <inheritdoc />
        public int Take { get; }

        /// <inheritdoc/>
        public Expression<Func<TAggregateRoot, bool>> Query { get; }
    }
}
