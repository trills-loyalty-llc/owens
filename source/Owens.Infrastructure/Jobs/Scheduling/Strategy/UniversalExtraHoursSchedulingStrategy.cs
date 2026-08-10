// <copyright file="UniversalExtraHoursSchedulingStrategy.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using ChainStrategy;
using Owens.Domain.ThemeParks;

namespace Owens.Infrastructure.Jobs.Scheduling.Strategy
{
    /// <inheritdoc />
    public class UniversalExtraHoursSchedulingStrategy : IStrategyHandler<SchedulingStrategyPayload, Admission>
    {
        /// <inheritdoc/>
        public Task<Admission> Handle(SchedulingStrategyPayload request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
