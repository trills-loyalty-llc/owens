// <copyright file="SchedulingStrategyProfile.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using ChainStrategy;
using Owens.Domain.ThemeParks;

namespace Owens.Infrastructure.Jobs.Scheduling.Strategy
{
    /// <inheritdoc />
    public class SchedulingStrategyProfile : StrategyProfile<SchedulingStrategyPayload, Admission>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SchedulingStrategyProfile"/> class.
        /// </summary>
        public SchedulingStrategyProfile()
        {
            AddStrategy<DisneyEarlyEntrySchedulingStrategy>(payload => payload.ScheduleType.Equals("ticketed_event", StringComparison.InvariantCultureIgnoreCase) && payload.ScheduleDescription.Equals("early entry", StringComparison.InvariantCultureIgnoreCase));
            AddStrategy<UniversalExtraHoursSchedulingStrategy>(payload => payload.ScheduleType.Equals("extra_hours", StringComparison.InvariantCultureIgnoreCase));
            AddStrategy<StandardOperatingSchedulingStrategy>(payload => payload.ScheduleType.Equals("operating", StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
