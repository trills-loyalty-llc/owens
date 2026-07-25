// <copyright file="QueueStatusJob.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using Owens.Application.Services.ThemeParks.Interfaces;
using Owens.Application.ThemeParks.Common;
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
        private readonly IThemeParkRepository _themeParkRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="QueueStatusJob"/> class.
        /// </summary>
        /// <param name="themeParkService">An instance of the <see cref="IThemeParksService"/> interface.</param>
        /// <param name="themeParkRepository">An instance of the <see cref="IThemeParkRepository"/> interface.</param>
        public QueueStatusJob(IThemeParksService themeParkService, IThemeParkRepository themeParkRepository)
        {
            _themeParksService = themeParkService;
            _themeParkRepository = themeParkRepository;
        }

        /// <inheritdoc/>
        public async Task Execute(IJobExecutionContext context)
        {
            var themeParks = await _themeParkRepository.GetAllObjects(context.CancellationToken);

            foreach (var themePark in themeParks)
            {
                var themeParkStatus = await _themeParksService.GetThemeParkStatus(themePark.Id, context.CancellationToken);

                foreach (var attraction in themePark.Attractions)
                {
                    var attractionStatus = themeParkStatus.Attractions.FirstOrDefault(statusTuple => attraction.Id == statusTuple.Id).QueueStatus;

                    if (attractionStatus != null)
                    {
                        attraction.AppendStatus(attractionStatus);
                    }
                }

                await _themeParkRepository.UpdateObject(themePark, context.CancellationToken);
            }
        }
    }
}
