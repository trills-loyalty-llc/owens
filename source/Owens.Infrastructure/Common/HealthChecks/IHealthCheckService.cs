// <copyright file="IHealthCheckService.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Owens.Infrastructure.Common.HealthChecks
{
    /// <summary>
    /// Interface for interacting with health checks.
    /// </summary>
    public interface IHealthCheckService
    {
        /// <summary>
        /// Gets the health check for the application.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<HealthReport> HealthCheckAsync(CancellationToken cancellationToken = default);
    }
}
