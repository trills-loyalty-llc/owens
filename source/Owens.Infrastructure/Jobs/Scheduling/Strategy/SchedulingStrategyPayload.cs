// <copyright file="SchedulingStrategyPayload.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using ChainStrategy;
using Owens.Application.Services.ThemeParks.Models;
using Owens.Domain.ThemeParks;

namespace Owens.Infrastructure.Jobs.Scheduling.Strategy
{
    /// <inheritdoc />
    public class SchedulingStrategyPayload : IStrategyRequest<Admission>
    {
        /// <summary>
        /// Gets the schedule type.
        /// </summary>
        public string ScheduleType { get; private set; } = string.Empty;

        /// <summary>
        /// Gets the description for a schedule.
        /// </summary>
        public string ScheduleDescription { get; private set; } = string.Empty;

        /// <summary>
        /// Creates a new instance of a payload.
        /// </summary>
        /// <param name="item">A <see cref="ParkScheduleItem"/> to create a payload against.</param>
        /// <returns>A <see cref="SchedulingStrategyPayload"/> instance.</returns>
        public static SchedulingStrategyPayload Instance(ParkScheduleItem item)
        {
            return new SchedulingStrategyPayload
            {
                ScheduleType = item.Type,
                ScheduleDescription = item.Description,
            };
        }
    }
}
