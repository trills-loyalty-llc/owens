// <copyright file="WaitTimesJob.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using Microsoft.Extensions.Logging;
using Quartz;

namespace Owens.Infrastructure.Jobs
{
    /// <inheritdoc />
    public class WaitTimesJob : IJob
    {
        /// <summary>
        /// Gets the job key.
        /// </summary>
        public static readonly JobKey WaitTimesJobKey = JobKey.Create("WaitTimesJobKey");

        private readonly ILogger<WaitTimesJob> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="WaitTimesJob"/> class.
        /// </summary>
        /// <param name="logger">An instance of the <see cref="ILogger{T}"/> interface.</param>
        public WaitTimesJob(ILogger<WaitTimesJob> logger)
        {
            _logger = logger;
        }

        /// <inheritdoc/>
        public Task Execute(IJobExecutionContext context)
        {
            _logger.LogInformation("Wait Times job ran at {DateTime}", DateTime.UtcNow);

            return Task.CompletedTask;
        }
    }
}
