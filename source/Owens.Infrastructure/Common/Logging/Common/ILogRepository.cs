// <copyright file="ILogRepository.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using Owens.Application.Common.DataAccess;

namespace Owens.Infrastructure.Common.Logging.Common
{
    /// <summary>
    /// Interface for interacting with logs.
    /// </summary>
    public interface ILogRepository
        : IGetPagination<Log>
    {
    }
}
