// <copyright file="LogRepository.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using MediatR;
using Owens.Infrastructure.DataAccess.Common;

namespace Owens.Infrastructure.Common.Logging.Common
{
    /// <inheritdoc cref="ILogRepository" />
    public class LogRepository : BaseRepository<Log>, ILogRepository
    {
        /// <inheritdoc />
        public LogRepository(IPublisher publisher, ApplicationContext context)
            : base(publisher, context)
        {
        }
    }
}
