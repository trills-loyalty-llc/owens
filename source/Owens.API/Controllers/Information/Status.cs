// <copyright file="Status.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Mvc;
using Owens.API.Common;
using Owens.Infrastructure.HealthChecks;

namespace Owens.API.Controllers.Information
{
    /// <inheritdoc />
    [ApiController]
    [Route("status")]
    public class Status : BaseController
    {
        private readonly IHealthCheckService _service;

        /// <summary>
        /// Initializes a new instance of the <see cref="Status"/> class.
        /// </summary>
        /// <param name="logger">An instance of the <see cref="ILogger{TCategoryName}"/> interface.</param>
        /// <param name="service">An instance of the <see cref="IHealthCheckService"/> interface.</param>
        public Status(ILogger<Status> logger, IHealthCheckService service)
            : base(logger)
        {
            _service = service;
        }

        /// <summary>
        /// Gets the current status of the application.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [HttpGet("health", Name = "GetHealthChecks")]
        [ProducesResponseType<HealthCheckResponse>(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetHealthStatusAsync(CancellationToken cancellationToken = default)
        {
            return await ExecuteOkObject(_service.HealthCheckAsync, new HealthCheckRequest(), cancellationToken);
        }
    }
}
