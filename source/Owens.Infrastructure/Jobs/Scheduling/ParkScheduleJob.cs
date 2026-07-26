// <copyright file="ParkScheduleJob.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using Owens.Application.Services.ThemeParks.Interfaces;
using Owens.Application.ThemeParks.Common;
using Quartz;

namespace Owens.Infrastructure.Jobs.Scheduling
{
    /// <inheritdoc />
    public class ParkScheduleJob : IJob
    {
        /// <summary>
        /// Gets the job key.
        /// </summary>
        public static readonly JobKey ParkScheduleJobKey = JobKey.Create("ParkScheduleJobKey");

        private readonly TimeProvider _timeProvider;
        private readonly IThemeParksService _themeParksService;
        private readonly IThemeParkRepository _themeParkRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ParkScheduleJob"/> class.
        /// </summary>
        /// <param name="timeProvider">An instance of the <see cref="TimeProvider"/> class.</param>
        /// <param name="themeParksService">An instance of the <see cref="IThemeParksService"/> interface.</param>
        /// <param name="themeParkRepository">An instance of the <see cref="IThemeParkRepository"/> interface.</param>
        public ParkScheduleJob(TimeProvider timeProvider, IThemeParksService themeParksService, IThemeParkRepository themeParkRepository)
        {
            _timeProvider = timeProvider;
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

                var today = _timeProvider.GetUtcNow().Date;

                var scheduleForToday = schedule.Schedules
                    .Where(parkScheduleItem => parkScheduleItem.Date == DateOnly.FromDateTime(today))
                    .ToList();

                // foreach (var ticketSchedule in schedule.Schedules)
                // {
                //    // Check for if schedule already exists.
                //    themePark.AppendSchedule(ticketSchedule);
                // }
                await _themeParkRepository.UpdateObject(themePark, context.CancellationToken);
            }
        }
    }
}
