// <copyright file="Status.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Mvc;
using NMediation.Abstractions;
using Owens.API.Common;
using Owens.Infrastructure.HealthChecks;

namespace Owens.API.Controllers.Information
{
    /// <inheritdoc />
    [ApiController]
    [Route("status")]
    public class Status : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Status"/> class.
        /// </summary>
        /// <param name="mediation">An instance of the <see cref="IMediation"/> payload.</param>
        public Status(IMediation mediation)
            : base(mediation)
        {
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
            return await ExecuteOkObject(new HealthCheckRequest(), cancellationToken);
        }
    }
}
