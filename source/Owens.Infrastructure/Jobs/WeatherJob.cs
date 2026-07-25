// <copyright file="WeatherJob.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using Owens.Application.Services.Weather.Interfaces;
using Owens.Application.ThemeParks.Common;
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

        private readonly IWeatherService _weatherService;
        private readonly IThemeParkRepository _themeParkRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="WeatherJob"/> class.
        /// </summary>
        /// <param name="weatherService">An instance of the <see cref="IWeatherService"/> interface.</param>
        /// <param name="themeParkRepository">An instance of the <see cref="IThemeParkRepository"/> interface.</param>
        public WeatherJob(IWeatherService weatherService, IThemeParkRepository themeParkRepository)
        {
            _weatherService = weatherService;
            _themeParkRepository = themeParkRepository;
        }

        /// <inheritdoc/>
        public async Task Execute(IJobExecutionContext context)
        {
            var themeParks = await _themeParkRepository.GetAllObjects(context.CancellationToken);

            foreach (var themePark in themeParks)
            {
                var weatherStatus = await _weatherService.GetWeatherAtLocation(themePark.Location, context.CancellationToken);

                themePark.AppendWeather(weatherStatus);

                await _themeParkRepository.UpdateObject(themePark, context.CancellationToken);
            }
        }
    }
}
