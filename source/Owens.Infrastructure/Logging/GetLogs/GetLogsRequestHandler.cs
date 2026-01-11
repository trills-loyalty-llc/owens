// <copyright file="GetLogsRequestHandler.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using Owens.Infrastructure.Logging.Common;

namespace Owens.Infrastructure.Logging.GetLogs
{
    /// <inheritdoc />
    public class GetLogsRequestHandler
    {
        private readonly ILogRepository _logRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetLogsRequestHandler"/> class.
        /// </summary>
        /// <param name="logRepository">An instance of the <see cref="ILogRepository"/> interface.</param>
        public GetLogsRequestHandler(ILogRepository logRepository)
        {
            _logRepository = logRepository;
        }

        /// <inheritdoc/>
        public async Task<GetLogsResponse> Handle(GetLogsRequest request, CancellationToken cancellationToken)
        {
            var result = await _logRepository.GetPaginatedRoots(LogPaginationQuery.FromRequest(request), cancellationToken);

            var responses = result.Roots.Select(LogResponse.FromLog);

            return new GetLogsResponse(responses, result.TotalCount);
        }
    }
}
