// <copyright file="ThemeParkFactory.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using FactoryFoundation;
using Owens.Application.Services.Weather.Models;
using Owens.Application.ThemeParks.AddThemePark;
using Owens.Domain.ThemeParks;

namespace Owens.Application.ThemeParks.Common
{
    /// <summary>
    /// Factory for theme parks.
    /// </summary>
    public class ThemeParkFactory :
        ICanTranslate<AddThemeParkRequest, ValidationEnvelope<ThemePark>>,
        ICanTranslate<ThemePark, AddThemeParkResponse>,
        ICanTranslate<CurrentWeather, WeatherStatus>
    {
        private readonly TimeProvider _timeProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="ThemeParkFactory"/> class.
        /// </summary>
        /// <param name="timeProvider">An instance of the <see cref="TimeProvider"/> class.</param>
        public ThemeParkFactory(TimeProvider timeProvider)
        {
            _timeProvider = timeProvider;
        }

        /// <inheritdoc/>
        public ValidationEnvelope<ThemePark> TranslateTo(AddThemeParkRequest initial)
        {
            return FactoryHelpers.TryCreateValidate(() => new ThemePark(
                initial.Description,
                LocationCoordinates.FromCoordinates(initial.Latitude, initial.Longitude)));
        }

        /// <inheritdoc/>
        public AddThemeParkResponse TranslateTo(ThemePark initial)
        {
            return new AddThemeParkResponse(initial.Id);
        }

        /// <inheritdoc/>
        public WeatherStatus TranslateTo(CurrentWeather initial)
        {
            return new WeatherStatus(_timeProvider.GetUtcNow(), initial.WindMph, initial.Conditions);
        }
    }
}
