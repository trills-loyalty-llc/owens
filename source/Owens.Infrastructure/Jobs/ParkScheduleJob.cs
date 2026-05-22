// <copyright file="ParkScheduleJob.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using Owens.Application.Services.ThemeParks.Interfaces;
using Owens.Application.ThemeParks.Common;
using Quartz;

namespace Owens.Infrastructure.Jobs
{
    /// <inheritdoc />
    public class ParkScheduleJob : IJob
    {
        /// <summary>
        /// Gets the job key.
        /// </summary>
        public static readonly JobKey ParkScheduleJobKey = JobKey.Create("ParkScheduleJobKey");

        private readonly IThemeParksService _themeParksService;
        private readonly IThemeParkRepository _themeParkRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ParkScheduleJob"/> class.
        /// </summary>
        /// <param name="themeParksService">An instance of the <see cref="IThemeParksService"/> interface.</param>
        /// <param name="themeParkRepository">An instance of the <see cref="IThemeParkRepository"/> interface.</param>
        public ParkScheduleJob(IThemeParksService themeParksService, IThemeParkRepository themeParkRepository)
        {
            _themeParksService = themeParksService;
            _themeParkRepository = themeParkRepository;
        }

        /// <inheritdoc/>
        public async Task Execute(IJobExecutionContext context)
        {
            var themeParksList = await _themeParkRepository.GetAllObjects(context.CancellationToken);

            foreach (var themePark in themeParksList)
            {
                var schedule = await _themeParksService.GetThemeParkSchedule(themePark.Id, context.CancellationToken);

                foreach (var ticketSchedule in schedule.Schedules)
                {
                    // Check for if schedule already exists.
                    themePark.AppendSchedule(ticketSchedule);
                }

                await _themeParkRepository.UpdateObject(themePark, context.CancellationToken);
            }
        }
    }
}
