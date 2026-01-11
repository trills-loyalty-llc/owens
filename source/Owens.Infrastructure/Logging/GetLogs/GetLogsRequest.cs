// <copyright file="GetLogsRequest.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using Owens.Application.Common.Contracts;

namespace Owens.Infrastructure.Logging.GetLogs
{
    /// <inheritdoc />
    public class GetLogsRequest : PaginationRequest
    {
        /// <inheritdoc />
        public GetLogsRequest(int skip, int take)
            : base(skip, take)
        {
        }
    }
}
