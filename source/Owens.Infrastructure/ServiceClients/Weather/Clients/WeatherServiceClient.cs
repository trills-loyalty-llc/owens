// <copyright file="WeatherServiceClient.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using FactoryFoundation;
using Microsoft.Extensions.Logging;
using Owens.Application.Services.Weather.Interfaces;
using Owens.Application.Services.Weather.Models;
using Owens.Domain.ThemeParks;
using Owens.Infrastructure.Dependencies;
using Owens.Infrastructure.ServiceClients.Common;
using Owens.Infrastructure.ServiceClients.Weather.Models;

namespace Owens.Infrastructure.ServiceClients.Weather.Clients
{
    /// <inheritdoc cref="IWeatherService" />
    public class WeatherServiceClient : BaseServiceClient, IWeatherService
    {
        private readonly ConfigurationOptions _options;

        /// <summary>
        /// Initializes a new instance of the <see cref="WeatherServiceClient"/> class.
        /// </summary>
        /// <param name="httpClient">An instance of the <see cref="HttpClient"/> class.</param>
        /// <param name="translator">An instance of the <see cref="ITranslator"/> interface.</param>
        /// <param name="logger">An instance of the <see cref="ILogger{T}"/> interface.</param>
        /// <param name="options">An instance of the <see cref="ConfigurationOptions"/> class.</param>
        public WeatherServiceClient(HttpClient httpClient, ITranslator translator, ILogger<BaseServiceClient> logger, ConfigurationOptions options)
            : base(httpClient, translator, logger)
        {
            _options = options;
        }

        /// <inheritdoc/>
        public async Task<CurrentWeather> GetWeatherAtLocation(LocationCoordinates coordinates, CancellationToken cancellationToken = default)
        {
            var uri = new Uri($"current.json?key={_options.WeatherKey}&q={coordinates.Latitude},{coordinates.Longitude}", UriKind.Relative);

            return await ExecuteGet<WeatherResponseWrapper, CurrentWeather>(uri, WeatherResponseWrapper.Default(), cancellationToken);
        }
    }
}
