﻿// <copyright file="GetLogsResponse.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using Owens.Application.Common.Contracts;
using Owens.Infrastructure.Common.Logging.Common;

namespace Owens.Infrastructure.Common.Logging.GetLogs
{
    /// <inheritdoc />
    public class GetLogsResponse : PaginationResponse<LogResponse>
    {
        /// <inheritdoc />
        public GetLogsResponse(IEnumerable<LogResponse> entities, int totalCount)
            : base(entities, totalCount)
        {
        }
    }
}
