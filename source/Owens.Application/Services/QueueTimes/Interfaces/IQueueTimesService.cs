// <copyright file="IQueueTimesService.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using Owens.Application.Services.QueueTimes.Models;

namespace Owens.Application.Services.QueueTimes.Interfaces
{
    /// <summary>
    /// A client to query for queue times.
    /// </summary>
    public interface IQueueTimesService
    {
        /// <summary>
        /// Retrieves queue times for a specified park.
        /// </summary>
        /// <param name="parkId">The external identifier for a park.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<List<RideQueueStatus>> GetQueueTimes(int parkId, CancellationToken cancellationToken = default);
    }
}
