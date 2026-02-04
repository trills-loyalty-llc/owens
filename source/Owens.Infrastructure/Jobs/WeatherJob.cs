// <copyright file="WeatherJob.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using FactoryFoundation;
using Microsoft.Extensions.Logging;
using Owens.Application.Services.Weather.Interfaces;
using Owens.Application.Services.Weather.Models;
using Owens.Application.ThemeParks.Common;
using Owens.Domain.ThemeParks;
using Quartz;

namespace Owens.Infrastructure.Jobs
{
    /// <inheritdoc />
    public class WeatherJob : IJob
    {
        /// <summary>
        /// Gets the job key.
        /// </summary>
        public static readonly JobKey WeatherJobKey = JobKey.Create("WeatherJobKey");

        private readonly TimeProvider _timeProvider;
        private readonly ILogger<WeatherJob> _logger;
        private readonly ITranslator _translator;
        private readonly IWeatherService _weatherService;
        private readonly IThemeParkRepository _themeParkRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="WeatherJob"/> class.
        /// </summary>
        /// <param name="timeProvider">An instance of the <see cref="TimeProvider"/> class.</param>
        /// <param name="logger">An instance of the <see cref="ILogger{T}"/> interface.</param>
        /// <param name="translator">An instance of the <see cref="ITranslator"/> interface.</param>
        /// <param name="weatherService">An instance of the <see cref="IWeatherService"/> interface.</param>
        /// <param name="themeParkRepository">An instance of the <see cref="IThemeParkRepository"/> interface.</param>
        public WeatherJob(TimeProvider timeProvider, ILogger<WeatherJob> logger, ITranslator translator, IWeatherService weatherService, IThemeParkRepository themeParkRepository)
        {
            _timeProvider = timeProvider;
            _logger = logger;
            _translator = translator;
            _weatherService = weatherService;
            _themeParkRepository = themeParkRepository;
        }

        /// <inheritdoc/>
        public async Task Execute(IJobExecutionContext context)
        {
            _logger.LogInformation("Weather job running at: {DateTime}", _timeProvider.GetUtcNow());

            var themeParks = await _themeParkRepository.GetAllObjects(context.CancellationToken);

            foreach (var themePark in themeParks)
            {
                var currentWeather = await _weatherService.GetWeatherAtLocation(themePark.Coordinates, context.CancellationToken);

                var weatherStatus = _translator.Translate<CurrentWeather, WeatherStatus>(currentWeather);

                themePark.AppendWeather(weatherStatus);

                await _themeParkRepository.UpdateObject(themePark, context.CancellationToken);
            }
        }
    }
}
