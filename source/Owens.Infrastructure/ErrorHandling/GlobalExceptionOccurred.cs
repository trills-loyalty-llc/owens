// <copyright file="GlobalExceptionOccurred.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using MediatR;

namespace Owens.Infrastructure.ErrorHandling
{
    /// <inheritdoc />
    public class GlobalExceptionOccurred : INotification
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GlobalExceptionOccurred"/> class.
        /// </summary>
        /// <param name="exception">The <see cref="Exception"/> that occurred.</param>
        public GlobalExceptionOccurred(Exception exception)
        {
            Exception = exception;
            Timestamp = DateTimeOffset.UtcNow;
        }

        /// <summary>
        /// Gets the global exception.
        /// </summary>
        public Exception Exception { get; }

        /// <summary>
        /// Gets the exception timestamp.
        /// </summary>
        public DateTimeOffset Timestamp { get; }
    }
}
