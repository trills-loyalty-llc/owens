// <copyright file="LogPaginationQuery.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using System.Linq.Expressions;
using Owens.Application.Common.Contracts;
using Owens.Application.Common.DataAccess;
using Owens.Infrastructure.Common.Logging.Common;

namespace Owens.Infrastructure.Common.Logging.GetLogs
{
    /// <inheritdoc />
    public class LogPaginationQuery : PaginationQuery<Log>
    {
        /// <inheritdoc />
        private LogPaginationQuery(IPagination pagination, Expression<Func<Log, bool>> query)
            : base(pagination, query)
        {
        }

        /// <summary>
        /// Creates a new pagination query.
        /// </summary>
        /// <param name="request">A <see cref="GetLogsRequest"/> object.</param>
        /// <returns>A new <see cref="LogPaginationQuery"/> instance.</returns>
        public static LogPaginationQuery FromRequest(GetLogsRequest request)
        {
            return new LogPaginationQuery(request, log => log.DateTimeOffset < DateTimeOffset.UtcNow);
        }
    }
}
