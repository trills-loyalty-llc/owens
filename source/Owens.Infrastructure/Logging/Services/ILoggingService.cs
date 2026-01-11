// <copyright file="ILoggingService.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using Owens.Application.Common.DataAccess;
using Owens.Infrastructure.Logging.Common;
using Owens.Infrastructure.Logging.GetLogs;

namespace Owens.Infrastructure.Logging.Services
{
    public interface ILoggingService
    {
        Task<PaginationResult<Log>> GetLogs(GetLogsRequest request, CancellationToken cancellationToken);
    }
}
