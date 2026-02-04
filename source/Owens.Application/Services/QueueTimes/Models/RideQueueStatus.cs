// <copyright file="RideQueueStatus.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

namespace Owens.Application.Services.QueueTimes.Models
{
    /// <summary>
    /// The result object for a queue time update.
    /// </summary>
    public class RideQueueStatus
    {
        /// <summary>
        /// Gets the ride external identifier.
        /// </summary>
        public int Id { get; init; }

        /// <summary>
        /// Gets the ride name.
        /// </summary>
        public string Name { get; init; } = string.Empty;

        /// <summary>
        /// Gets a value indicating whether the ride is operational.
        /// </summary>
        public bool IsOperational { get; init; }

        /// <summary>
        /// Gets the wait time.
        /// </summary>
        public TimeSpan Wait { get; init; }
    }
}
