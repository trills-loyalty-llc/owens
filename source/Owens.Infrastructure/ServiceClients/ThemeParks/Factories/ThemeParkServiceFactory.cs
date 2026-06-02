// <copyright file="ThemeParkServiceFactory.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using FactoryFoundation;
using Owens.Application.Services.ThemeParks.Models;
using Owens.Domain.Attractions;
using Owens.Domain.Common;
using Owens.Domain.ThemeParks;
using Owens.Infrastructure.ServiceClients.ThemeParks.Models;

namespace Owens.Infrastructure.ServiceClients.ThemeParks.Factories
{
    /// <summary>
    /// Factory for the theme park service client.
    /// </summary>
    public class ThemeParkServiceFactory :
        ICanTranslate<LiveStatusResult, ParkStatus>,
        ICanTranslate<ScheduleResult, ParkSchedule>
    {
        private readonly TimeProvider _timeProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="ThemeParkServiceFactory"/> class.
        /// </summary>
        /// <param name="timeProvider">An instance of the <see cref="TimeProvider"/> class.</param>
        public ThemeParkServiceFactory(TimeProvider timeProvider)
        {
            _timeProvider = timeProvider;
        }

        /// <inheritdoc/>
        public ParkStatus TranslateTo(LiveStatusResult first)
        {
            return new ParkStatus
            {
                Attractions = first.LiveData
                    .Select(dataResult => (
                        dataResult.Id,
                        new QueueStatus(
                        TimeSpan.FromMinutes(dataResult.Queue.StandBy.WaitInMinutes ?? 0),
                        _timeProvider.GetUtcNow(),
                        Enum.Parse<OperatingStatus>(dataResult.Status, true))))
                    .ToList(),
            };
        }

        /// <inheritdoc/>
        public ParkSchedule TranslateTo(ScheduleResult first)
        {
            return new ParkSchedule
            {
                Schedules = first.Schedule
                    .Select(scheduleResult => new Admission(
                        scheduleResult.OpeningTime,
                        scheduleResult.ClosingTime,
                        new Ticketing(string.Empty, 0m, TicketingType.Normal)))
                    .ToList(),
            };
        }
    }
}
