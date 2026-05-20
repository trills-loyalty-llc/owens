// <copyright file="LiveDataResult.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

namespace Owens.Infrastructure.ServiceClients.ThemeParks.Models
{
    /// <summary>
    /// Live attraction data from the external client.
    /// </summary>
    public class LiveDataResult
    {
        /// <summary>
        /// Gets the entity identifier.
        /// </summary>
        public Guid Id { get; init; }

        /// <summary>
        /// Gets the queue result.
        /// </summary>
        public QueueResult Queue { get; init; } = QueueResult.Empty();

        /// <summary>
        /// Gets the attraction status.
        /// </summary>
        public string Status { get; init; } = string.Empty;
    }
}
