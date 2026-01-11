// <copyright file="ILogger.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

namespace Owens.Infrastructure.Logging.Common
{
    /// <summary>
    /// Interface for interacting with the application logger.
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Logs an exception.
        /// </summary>
        /// <param name="exception">A <see cref="Exception"/> for logging.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task LogException(Exception exception, CancellationToken cancellationToken);
    }
}
