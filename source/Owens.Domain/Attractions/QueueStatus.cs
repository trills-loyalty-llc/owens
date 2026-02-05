// <copyright file="QueueStatus.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using ClearDomain.GuidPrimary;

namespace Owens.Domain.Attractions
{
    /// <inheritdoc />
    public class QueueStatus : Entity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QueueStatus"/> class.
        /// </summary>
        /// <param name="id">The identifier of the entity.</param>
        /// <param name="wait">The wait time for the attraction.</param>
        /// <param name="timeStamp">The timestamp of the status update.</param>
        /// <param name="isOperational">Designates if the attraction is open.</param>
        public QueueStatus(Guid id, TimeSpan wait, DateTimeOffset timeStamp, bool isOperational)
            : base(id)
        {
            Wait = wait;
            TimeStamp = timeStamp;
            IsOperational = isOperational;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueueStatus"/> class.
        /// </summary>
        /// <param name="wait">The wait time for the attraction.</param>
        /// <param name="timeStamp">The timestamp of the status update.</param>
        /// <param name="isOperational">Designates if the attraction is open.</param>
        public QueueStatus(TimeSpan wait, DateTimeOffset timeStamp, bool isOperational)
        {
            Wait = wait;
            TimeStamp = timeStamp;
            IsOperational = isOperational;
        }

        /// <summary>
        /// Gets the wait time at a specified timestamp.
        /// </summary>
        public TimeSpan Wait { get; }

        /// <summary>
        /// Gets the timestamp for the status update. Always in UTC.
        /// </summary>
        public DateTimeOffset TimeStamp { get; }

        /// <summary>
        /// Gets a value indicating whether the attraction is operating.
        /// </summary>
        public bool IsOperational { get; }
    }
}
