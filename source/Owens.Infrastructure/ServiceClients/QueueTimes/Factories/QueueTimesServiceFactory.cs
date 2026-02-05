// <copyright file="QueueTimesServiceFactory.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using FactoryFoundation;
using Owens.Application.Services.QueueTimes.Models;
using Owens.Infrastructure.ServiceClients.QueueTimes.Models;

namespace Owens.Infrastructure.ServiceClients.QueueTimes.Factories
{
    /// <inheritdoc />
    public class QueueTimesServiceFactory : ICanTranslate<QueueTimesResponseWrapper, List<RideQueueStatus>>
    {
        /// <inheritdoc/>
        public List<RideQueueStatus> TranslateTo(QueueTimesResponseWrapper initial)
        {
            return initial.Lands
                .SelectMany(landResponse => landResponse.Rides
                    .Select(rideResponse => new RideQueueStatus
                    {
                        Id = rideResponse.Id,
                        Name = rideResponse.Name,
                        IsOperational = rideResponse.IsOpen,
                        Wait = TimeSpan.FromMinutes(rideResponse.WaitTime),
                    })).ToList();
        }
    }
}
