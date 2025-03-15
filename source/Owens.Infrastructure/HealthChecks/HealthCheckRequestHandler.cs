// <copyright file="HealthCheckRequestHandler.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using MediatorBuddy;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Owens.Infrastructure.Common.HealthChecks;

namespace Owens.Infrastructure.HealthChecks
{
    /// <inheritdoc />
    public class HealthCheckRequestHandler : EnvelopeHandler<HealthCheckRequest, HealthCheckResponse>
    {
        private readonly IHealthCheckService _healthCheckService;

        /// <summary>
        /// Initializes a new instance of the <see cref="HealthCheckRequestHandler"/> class.
        /// </summary>
        /// <param name="healthCheckService">An instance of the <see cref="HealthCheckService"/> class.</param>
        public HealthCheckRequestHandler(IHealthCheckService healthCheckService)
        {
            _healthCheckService = healthCheckService;
        }

        /// <inheritdoc />
        public override async Task<IEnvelope<HealthCheckResponse>> Handle(HealthCheckRequest request, CancellationToken cancellationToken)
        {
            var report = await _healthCheckService.HealthCheckAsync(cancellationToken);

            var response = HealthCheckResponse.FromReport(report);

            return Success(response);
        }
    }
}
