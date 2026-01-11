// <copyright file="HealthCheckManager.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Owens.Infrastructure.HealthChecks
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
        public async Task<HealthCheckResponse> HealthCheckAsync(HealthCheckRequest request, CancellationToken cancellationToken = default)
        {
            var report = await _healthCheckService.CheckHealthAsync(cancellationToken);

            return HealthCheckResponse.FromReport(report);
        }
    }
}
