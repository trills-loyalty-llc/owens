// <copyright file="ThemeParkServiceFactory.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using FactoryFoundation;
using Owens.Domain.Attractions;
using Owens.Infrastructure.ServiceClients.ThemeParks.Models;

namespace Owens.Infrastructure.ServiceClients.ThemeParks.Factories
{
    /// <summary>
    /// Factory for the theme park service client.
    /// </summary>
    public class ThemeParkServiceFactory : ICanTranslate<EntityResult, QueueStatus>
    {
        /// <inheritdoc/>
        public QueueStatus TranslateTo(EntityResult first)
        {
            var entity = first.LiveData.First();

            var status = Enum.Parse<OperationalStatus>(entity.Status, true);

            return new QueueStatus(TimeSpan.FromMinutes(entity.Queue.StandBy.WaitInMinutes), DateTimeOffset.UtcNow, status);
        }
    }
}
