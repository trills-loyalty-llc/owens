// <copyright file="WeatherServiceFactory.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using FactoryFoundation;
using Owens.Domain.ThemeParks;
using Owens.Infrastructure.ServiceClients.Weather.Models;

namespace Owens.Infrastructure.ServiceClients.Weather.Factories
{
    /// <inheritdoc />
    public class WeatherServiceFactory :
        ICanTranslate<WeatherResponseWrapper, WeatherStatus>
    {
        private readonly TimeProvider _timeProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="WeatherServiceFactory"/> class.
        /// </summary>
        /// <param name="timeProvider">An instance of the <see cref="TimeProvider"/> class.</param>
        public WeatherServiceFactory(TimeProvider timeProvider)
        {
            _timeProvider = timeProvider;
        }

        /// <inheritdoc/>
        public WeatherStatus TranslateTo(WeatherResponseWrapper initial)
        {
            var response = initial.Current;

            return new WeatherStatus(
                _timeProvider.GetUtcNow(),
                (int)response.TemperatureFahrenheit,
                (int)response.FeelsLikeFahrenheit,
                (int)response.HeatIndexFahrenheit,
                response.IsDaylight > 0,
                response.UltraVioletIndex,
                response.Humidity,
                response.WindMph,
                response.CloudCoverage,
                response.WillItRain > 0,
                (int)response.ChanceOfRain,
                response.PrecipitationInInches,
                response.Conditions.ConditionsCode,
                response.Conditions.Description);
        }
    }
}
