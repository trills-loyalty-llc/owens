﻿// <copyright file="HealthCheckController.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using MediatorBuddy.AspNet;
using MediatorBuddy.AspNet.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Owens.Infrastructure.HealthChecks;

namespace Owens.API.Controllers
{
    /// <inheritdoc />
    [ApiController]
    [Route("health-check")]
    public class HealthCheckController : MediatorBuddyApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HealthCheckController"/> class.
        /// </summary>
        /// <param name="mediator">An instance of the <see cref="IMediator"/> interface.</param>
        public HealthCheckController(IMediator mediator)
            : base(mediator)
        {
        }

        /// <summary>
        /// Gets the current status of the application.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [HttpGet("", Name = "HealthCheck")]
        [ProducesResponseType<HealthReport>(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetHealthStatusAsync()
        {
            return await ExecuteRequest(new HealthCheckRequest(), ResponseOptions.OkObjectResponse<HealthCheckResponse>());
        }
    }
}
