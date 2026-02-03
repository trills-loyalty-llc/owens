// <copyright file="GetLogsRequest.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using Owens.Application.Common.Contracts;
using Owens.Application.Common.Mediation;

namespace Owens.Infrastructure.Logging.GetLogs
{
    /// <inheritdoc />
    public class GetLogsRequest : PaginationRequest, IEnvelopePayload<GetLogsResponse>
    {
        /// <inheritdoc />
        public GetLogsRequest(int skip, int take)
            : base(skip, take)
        {
        }
    }
}
