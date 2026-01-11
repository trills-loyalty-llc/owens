// <copyright file="Logger.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using Owens.Infrastructure.DataAccess.Common;

namespace Owens.Infrastructure.Logging.Common
{
    /// <inheritdoc />
    internal class Logger : ILogger
    {
        private readonly ApplicationContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="Logger"/> class.
        /// </summary>
        /// <param name="context">An instance of the <see cref="ApplicationContext"/> class.</param>
        public Logger(ApplicationContext context)
        {
            _context = context;
        }

        /// <inheritdoc/>
        public async Task LogException(Exception exception, CancellationToken cancellationToken)
        {
            await _context.Logs.AddAsync(new Log(DateTimeOffset.UtcNow), cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
