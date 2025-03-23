// <copyright file="GetLogsRequest.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using MediatorBuddy;
using Owens.Application.Common.Contracts;

namespace Owens.Infrastructure.Common.Logging.GetLogs
{
    /// <inheritdoc cref="IEnvelopeRequest{TResponse}" />
    public class GetLogsRequest : PaginationRequest, IEnvelopeRequest<GetLogsResponse>
    {
        /// <inheritdoc />
        public GetLogsRequest(int skip, int take)
            : base(skip, take)
        {
        }
    }
}
