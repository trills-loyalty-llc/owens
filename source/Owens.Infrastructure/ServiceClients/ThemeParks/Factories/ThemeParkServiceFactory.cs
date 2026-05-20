// <copyright file="ThemeParkServiceFactory.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using FactoryFoundation;
using Owens.Application.Services.ThemeParks.Models;
using Owens.Domain.Attractions;
using Owens.Domain.Common;
using Owens.Infrastructure.ServiceClients.ThemeParks.Models;

namespace Owens.Infrastructure.ServiceClients.ThemeParks.Factories
{
    /// <summary>
    /// Factory for the theme park service client.
    /// </summary>
    public class ThemeParkServiceFactory : ICanTranslate<EntityResult, ThemeParkStatus>
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
        public ThemeParkStatus TranslateTo(EntityResult first)
        {
            return new ThemeParkStatus
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
    }
}
