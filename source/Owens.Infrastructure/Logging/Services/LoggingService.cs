// <copyright file="LoggingService.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using Owens.Application.Common.DataAccess;
using Owens.Infrastructure.Logging.Common;
using Owens.Infrastructure.Logging.GetLogs;

namespace Owens.Infrastructure.Logging.Services
{
    /// <inheritdoc />
    public class LoggingService : ILoggingService
    {
        private readonly ILogRepository _logRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoggingService"/> class.
        /// </summary>
        /// <param name="logRepository">An instance of the <see cref="ILogRepository"/> interface.</param>
        public LoggingService(ILogRepository logRepository)
        {
            _logRepository = logRepository;
        }

        /// <inheritdoc/>
        public async Task<PaginationResult<Log>> GetLogs(GetLogsRequest request, CancellationToken cancellationToken)
        {
            var paginationResult = await _logRepository.GetPaginatedRoots(LogPaginationQuery.FromRequest(request), cancellationToken);

            return paginationResult;
        }
    }
}
