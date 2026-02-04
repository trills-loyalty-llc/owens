// <copyright file="WeatherFactory.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using FactoryFoundation;
using Owens.Application.Services.Weather.Models;
using Owens.Infrastructure.ServiceClients.Weather.Models;

namespace Owens.Infrastructure.ServiceClients.Weather.Factories
{
    /// <inheritdoc />
    public class WeatherFactory : ICanTranslate<WeatherResponseWrapper, CurrentWeather>
    {
        /// <inheritdoc/>
        public CurrentWeather TranslateTo(WeatherResponseWrapper initial)
        {
            return new CurrentWeather
            {
                TemperatureFahrenheit = initial.Current.TemperatureFahrenheit,
                WindMph = initial.Current.WindMph,
                Conditions = initial.Current.Conditions.Description,
                ConditionsCode = initial.Current.Conditions.ConditionsCode,
            };
        }
    }
}
