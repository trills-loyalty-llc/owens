// <copyright file="WaitTimesJob.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using Microsoft.Extensions.Logging;
using Owens.Application.Attractions.Common;
using Owens.Application.Services.QueueTimes.Interfaces;
using Owens.Domain.Attractions;
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

        private readonly IQueueTimesService _queueTimesService;
        private readonly ILogger<WaitTimesJob> _logger;
        private readonly TimeProvider _timeProvider;
        private readonly IAttractionRepository _attractionRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="WaitTimesJob"/> class.
        /// </summary>
        /// <param name="logger">An instance of the <see cref="ILogger{T}"/> interface.</param>
        /// <param name="queueTimesService">An instance of the <see cref="IQueueTimesService"/> interface.</param>
        /// <param name="timeProvider">An instance of the <see cref="TimeProvider"/> class.</param>
        /// <param name="attractionRepository">An instance of the <see cref="IAttractionRepository"/> interface.</param>
        public WaitTimesJob(ILogger<WaitTimesJob> logger, IQueueTimesService queueTimesService, TimeProvider timeProvider, IAttractionRepository attractionRepository)
        {
            _logger = logger;
            _queueTimesService = queueTimesService;
            _timeProvider = timeProvider;
            _attractionRepository = attractionRepository;
        }

        /// <inheritdoc/>
        public async Task Execute(IJobExecutionContext context)
        {
            var responses = await _queueTimesService.GetQueueTimes(334, context.CancellationToken);

            foreach (var response in responses)
            {
                var exists = await _attractionRepository.GetByExternalId(response.Id, context.CancellationToken);

                if (exists != null)
                {
                    exists.AppendStatus(new QueueStatus(response.Wait, _timeProvider.GetUtcNow(), response.IsOperational));

                    await _attractionRepository.UpdateObject(exists, context.CancellationToken);
                }
            }

            _logger.LogInformation("Wait Times job ran at {DateTime}", _timeProvider.GetUtcNow());
        }
    }
}
