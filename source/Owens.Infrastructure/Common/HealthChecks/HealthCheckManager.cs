// <copyright file="HealthCheckManager.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Owens.Infrastructure.Common.HealthChecks
{
    /// <inheritdoc />
    public class HealthCheckManager : IHealthCheckService
    {
        private readonly HealthCheckService _healthCheckService;

        /// <summary>
        /// Initializes a new instance of the <see cref="HealthCheckManager"/> class.
        /// </summary>
        /// <param name="healthCheckService">An instance of the <see cref="HealthCheckService"/> class.</param>
        public HealthCheckManager(HealthCheckService healthCheckService)
        {
            _healthCheckService = healthCheckService;
        }

        /// <inheritdoc/>
        public async Task<HealthReport> HealthCheckAsync(CancellationToken cancellationToken = default)
        {
            return await _healthCheckService.CheckHealthAsync(cancellationToken);
        }
    }
}
