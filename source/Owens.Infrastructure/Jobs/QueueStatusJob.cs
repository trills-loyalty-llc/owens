// <copyright file="QueueStatusJob.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using Microsoft.Extensions.Logging;
using Owens.Application.Attractions.Common;
using Owens.Application.Services.ThemeParks.Interfaces;
using Quartz;

namespace Owens.Infrastructure.Jobs
{
    /// <inheritdoc />
    public class QueueStatusJob : IJob
    {
        /// <summary>
        /// Gets the job key.
        /// </summary>
        public static readonly JobKey QueueStatusJobKey = JobKey.Create("QueueStatusJobKey");

        private readonly IThemeParksService _themeParksService;
        private readonly ILogger<QueueStatusJob> _logger;
        private readonly TimeProvider _timeProvider;
        private readonly IAttractionRepository _attractionRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="QueueStatusJob"/> class.
        /// </summary>
        /// <param name="logger">An instance of the <see cref="ILogger{T}"/> interface.</param>
        /// <param name="themeParkService">An instance of the <see cref="IThemeParksService"/> interface.</param>
        /// <param name="timeProvider">An instance of the <see cref="TimeProvider"/> class.</param>
        /// <param name="attractionRepository">An instance of the <see cref="IAttractionRepository"/> interface.</param>
        public QueueStatusJob(ILogger<QueueStatusJob> logger, IThemeParksService themeParkService, TimeProvider timeProvider, IAttractionRepository attractionRepository)
        {
            _logger = logger;
            _themeParksService = themeParkService;
            _timeProvider = timeProvider;
            _attractionRepository = attractionRepository;
        }

        /// <inheritdoc/>
        public async Task Execute(IJobExecutionContext context)
        {
            var attractionList = await _attractionRepository.GetAllObjects(context.CancellationToken);

            foreach (var attraction in attractionList)
            {
                var status = await _themeParksService.GetCurrentStatus(attraction.Id, context.CancellationToken);

                attraction.AppendStatus(status);

                await _attractionRepository.UpdateObject(attraction, context.CancellationToken);
            }

            _logger.LogInformation("Wait Times job ran at {DateTime}", _timeProvider.GetUtcNow());
        }
    }
}
