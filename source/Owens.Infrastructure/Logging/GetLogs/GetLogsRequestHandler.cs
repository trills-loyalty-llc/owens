// <copyright file="GetLogsRequestHandler.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using Owens.Application.Common.Mediation;
using Owens.Infrastructure.Logging.Common;

namespace Owens.Infrastructure.Logging.GetLogs
{
    /// <inheritdoc />
    public class GetLogsRequestHandler : EnvelopeHandler<GetLogsRequest, GetLogsResponse>
    {
        /// <inheritdoc/>
        public override Task<Envelope<GetLogsResponse>> Handle(GetLogsRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult(Success(new GetLogsResponse(new List<LogResponse>(), 0)));
        }
    }
}
