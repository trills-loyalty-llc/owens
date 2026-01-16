// <copyright file="ILoggingService.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using Owens.Application.Common.DataAccess;
using Owens.Infrastructure.Logging.Common;
using Owens.Infrastructure.Logging.GetLogs;

namespace Owens.Infrastructure.Logging.Services
{
    /// <summary>
    /// Interface for log operation.
    /// </summary>
    public interface ILoggingService
    {
        /// <summary>
        /// Retrieves paginated logs.
        /// </summary>
        /// <param name="request">A <see cref="GetLogsRequest"/> object.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<PaginationResult<Log>> GetLogs(GetLogsRequest request, CancellationToken cancellationToken);
    }
}
