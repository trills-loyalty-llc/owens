// <copyright file="HealthCheckHandler.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using Owens.Application.Common.Mediation;

namespace Owens.Infrastructure.HealthChecks
{
    /// <inheritdoc />
    public class HealthCheckHandler : EnvelopeHandler<HealthCheckRequest, HealthCheckResponse>
    {
        private readonly IHealthCheckService _healthCheckService;

        /// <summary>
        /// Initializes a new instance of the <see cref="HealthCheckHandler"/> class.
        /// </summary>
        /// <param name="healthCheckService">An instance of the <see cref="IHealthCheckService"/> interface.</param>
        public HealthCheckHandler(IHealthCheckService healthCheckService)
        {
            _healthCheckService = healthCheckService;
        }

        /// <inheritdoc/>
        public override async Task<Envelope<HealthCheckResponse>> Handle(HealthCheckRequest payload, CancellationToken cancellationToken)
        {
            var status = await _healthCheckService.HealthCheckAsync(cancellationToken);

            return Success(status);
        }
    }
}
