// <copyright file="LogRepository.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using Owens.Infrastructure.DataAccess.Common;
using Owens.Infrastructure.Logging.Common;

namespace Owens.Infrastructure.DataAccess.Logging
{
    /// <inheritdoc cref="ILogRepository" />
    public class LogRepository : BaseRepository<Log>, ILogRepository
    {
        /// <inheritdoc />
        public LogRepository(ApplicationContext context)
            : base(context)
        {
        }
    }
}
