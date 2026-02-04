// <copyright file="BaseServiceClient.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using FactoryFoundation;
using Microsoft.Extensions.Logging;
using System.Net.Http.Json;

namespace Owens.Infrastructure.ServiceClients.Common
{
    /// <summary>
    /// Base class for all service clients.
    /// </summary>
    public abstract class BaseServiceClient
    {
        private readonly HttpClient _httpClient;
        private readonly ITranslator _translator;
        private readonly ILogger<BaseServiceClient> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseServiceClient"/> class.
        /// </summary>
        /// <param name="httpClient">An instance of the <see cref="HttpClient"/> class.</param>
        /// <param name="translator">An instance of the <see cref="ITranslator"/> interface.</param>
        /// <param name="logger">An instance of the <see cref="ILogger{T}"/> interface.</param>
        protected BaseServiceClient(HttpClient httpClient, ITranslator translator, ILogger<BaseServiceClient> logger)
        {
            _httpClient = httpClient;
            _translator = translator;
            _logger = logger;
        }

        /// <summary>
        /// Executes a GET request.
        /// </summary>
        /// <typeparam name="TResult">The type of the result from the client.</typeparam>
        /// <typeparam name="TResponse">The type of the response.</typeparam>
        /// <param name="uri">A <see cref="Uri"/> to attempt to hit.</param>
        /// <param name="defaultValue">The default value used on failure.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        protected async Task<TResponse> ExecuteGet<TResult, TResponse>(Uri uri, TResult defaultValue, CancellationToken cancellationToken = default)
            where TResponse : class
            where TResult : class
        {
            TResult result = defaultValue;

            try
            {
                var message = await _httpClient.GetAsync(uri, cancellationToken);

                if (message.IsSuccessStatusCode)
                {
                    result = await message.Content.ReadFromJsonAsync<TResult>(cancellationToken) ?? defaultValue;
                }
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "A service client failed for {Uri}", uri);
            }

            return _translator.Translate<TResult, TResponse>(result);
        }
    }
}
