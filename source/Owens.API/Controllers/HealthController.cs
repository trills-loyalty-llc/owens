// <copyright file="HealthController.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using MediatR;
using Microsoft.AspNetCore.Mvc;
using Owens.API.Common;
using Owens.Infrastructure.Common.Logging.GetLogs;
using Owens.Infrastructure.HealthChecks;

namespace Owens.API.Controllers
{
    /// <inheritdoc />
    [ApiController]
    [Route("health")]
    public class HealthController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HealthController"/> class.
        /// </summary>
        /// <param name="mediator">An instance of the <see cref="IMediator"/> interface.</param>
        public HealthController(IMediator mediator)
            : base(mediator)
        {
        }

        /// <summary>
        /// Gets the current status of the application.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [HttpGet("health", Name = "HealthCheck")]
        [ProducesResponseType<HealthCheckResponse>(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetHealthStatusAsync(CancellationToken cancellationToken = default)
        {
            return await ExecuteOkObject(new HealthCheckRequest(), cancellationToken);
        }

        /// <summary>
        /// Returns a response for logs.
        /// </summary>
        /// <param name="skip">The number of logs to skip.</param>
        /// <param name="take">The number of logs to return.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [HttpGet("logs", Name = "Logs")]
        [ProducesResponseType<GetLogsResponse>(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetLogs(int skip = 0, int take = 10, CancellationToken cancellationToken = default)
        {
            return await ExecuteOkObject(new GetLogsRequest(skip, take), cancellationToken);
        }
    }
}
