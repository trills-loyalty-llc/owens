// <copyright file="Log.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using ClearDomain.GuidPrimary;

namespace Owens.Infrastructure.Logging.Common
{
    /// <inheritdoc />
    public class Log : AggregateRoot
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Log"/> class.
        /// </summary>
        /// <param name="dateTimeOffset">The log timestamp.</param>
        public Log(DateTimeOffset dateTimeOffset)
        {
            DateTimeOffset = dateTimeOffset;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Log"/> class.
        /// </summary>
        /// <param name="id">The identifier for the log.</param>
        /// <param name="dateTimeOffset">The log timestamp.</param>
        public Log(Guid id, DateTimeOffset dateTimeOffset)
            : base(id)
        {
            DateTimeOffset = dateTimeOffset;
        }

        /// <summary>
        /// Gets the timestamp.
        /// </summary>
        public DateTimeOffset DateTimeOffset { get; }
    }
}
