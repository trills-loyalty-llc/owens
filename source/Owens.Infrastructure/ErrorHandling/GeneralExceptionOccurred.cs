// <copyright file="GeneralExceptionOccurred.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using NMediation.Abstractions;

namespace Owens.Infrastructure.ErrorHandling
{
    /// <summary>
    /// Base class for global exception.
    /// </summary>
    public class GeneralExceptionOccurred : IOccurrence
    {
        private GeneralExceptionOccurred(Exception exception)
        {
            Exception = exception;
            DateTimeOffset = DateTimeOffset.UtcNow;
        }

        /// <summary>
        /// Gets the exception.
        /// </summary>
        public Exception Exception { get; }

        /// <summary>
        /// Gets the timestamp of the exception.
        /// </summary>
        public DateTimeOffset DateTimeOffset { get; }

        /// <summary>
        /// Instantiates a new <see cref="GeneralExceptionOccurred"/> object.
        /// </summary>
        /// <param name="exception">The <see cref="Exception"/> produced.</param>
        /// <returns>A new <see cref="GeneralExceptionOccurred"/> instance.</returns>
        public static GeneralExceptionOccurred FromException(Exception exception)
        {
            return new GeneralExceptionOccurred(exception);
        }
    }
}
