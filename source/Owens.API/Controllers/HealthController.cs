// <copyright file="HealthController.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Mvc;
using Owens.API.Common;
using Owens.Infrastructure.HealthChecks;
using Owens.Infrastructure.Logging.Common;
using Owens.Infrastructure.Logging.GetLogs;
using Owens.Infrastructure.Logging.Services;

namespace Owens.API.Controllers
{
    /// <inheritdoc />
    [ApiController]
    [Route("health")]
    public class HealthController : BaseController
    {
        private readonly IHealthCheckService _service;
        private readonly ILoggingService _loggingService;

        /// <summary>
        /// Initializes a new instance of the <see cref="HealthController"/> class.
        /// </summary>
        /// <param name="logger">An instance of the <see cref="ILogger{TCategoryName}"/> interface.</param>
        /// <param name="service">An instance of the <see cref="IHealthCheckService"/> interface.</param>
        /// <param name="loggingService">An instance of the <see cref="ILogRepository"/> interface.</param>
        public HealthController(ILogger<HealthController> logger, IHealthCheckService service, ILoggingService loggingService)
            : base(logger)
        {
            _service = service;
            _loggingService = loggingService;
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

        /// <summary>
        /// Returns a response for logs.
        /// </summary>
        /// <param name="skip">The number of logs to skip.</param>
        /// <param name="take">The number of logs to return.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [HttpGet("logs", Name = "GetLogs")]
        [ProducesResponseType<GetLogsResponse>(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetLogs(int skip = 0, int take = 10, CancellationToken cancellationToken = default)
        {
            return await ExecuteOkObject(_loggingService.GetLogs, new GetLogsRequest(skip, take), cancellationToken);
        }
    }
}
