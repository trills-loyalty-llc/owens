// <copyright file="GetLogsRequestHandler.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using Owens.Infrastructure.Logging.Common;

namespace Owens.Infrastructure.Logging.GetLogs
{
    /// <inheritdoc />
    public class GetLogsRequestHandler
    {
        /// <inheritdoc/>
        public Task<GetLogsResponse> Handle(GetLogsRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new GetLogsResponse(new List<LogResponse>(), 0));
        }
    }
}
