// <copyright file="IntegrationHelpers.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using MediatorBuddy;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Owens.Infrastructure.DataAccess.Common;
using Owens.Infrastructure.Dependencies;
using Owens.Infrastructure.Identity.Models;

namespace Owens.Tests.Integration.Common
{
    /// <summary>
    /// Helper class for integration tests.
    /// </summary>
    public static class IntegrationHelpers
    {
        private static IServiceProvider? _serviceProvider;

        /// <summary>
        /// Gets a registered service.
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <returns>An instance of the service requested.</returns>
        public static TService GetService<TService>()
            where TService : class
        {
            return GetProvider().GetRequiredService<TService>();
        }

        /// <summary>
        /// Gets a request handler for a specified type.
        /// </summary>
        /// <typeparam name="TRequest">The request type.</typeparam>
        /// <typeparam name="TResponse">The request response.</typeparam>
        /// <returns>A <see cref="IEnvelopeHandler{TRequest,TResponse}"/>.</returns>
        public static IRequestHandler<TRequest, IEnvelope<TResponse>> GetEnvelopeHandler<TRequest, TResponse>()
            where TRequest : IEnvelopeRequest<TResponse>
        {
            return GetProvider().GetRequiredService<IRequestHandler<TRequest, IEnvelope<TResponse>>>();
        }

        /// <summary>
        /// Gets the application context options.
        /// </summary>
        /// <returns>A <see cref="DbContextOptions"/> instance.</returns>
        public static DbContextOptions<ApplicationContext> GetApplicationOptions()
        {
            var builder = new DbContextOptionsBuilder<ApplicationContext>();
            builder.UseSqlServer(GetApplicationConnectionString());

            return builder.Options;
        }

        /// <summary>
        /// Gets the application connection string.
        /// </summary>
        /// <returns>A connection string.</returns>
        private static string GetApplicationConnectionString()
        {
            return Environment.GetEnvironmentVariable("SQL_SERVER_CONNECTION_STRING") ??
                   "Server=.\\SQLExpress;Database=Owens.Tests;Trusted_Connection=True;MultipleActiveResultSets=true;Integrated Security=True;TrustServerCertificate=true";
        }

        private static IServiceProvider GetProvider()
        {
            if (_serviceProvider == null)
            {
                var collection = new ServiceCollection();

                var configuration = new ConfigurationBuilder()
                    .AddInMemoryCollection(new List<KeyValuePair<string, string?>>
                    {
                        new KeyValuePair<string, string?>("ConnectionStrings:Database", GetApplicationConnectionString()),
                    })
                    .Build();

                collection.RegisterDependencies(configuration);
                collection.AddLogging();
                collection.AddAuthenticationDependencies(new TokenConfiguration(Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString()));

                var provider = collection.BuildServiceProvider();
                _serviceProvider = provider;

                return provider;
            }

            return _serviceProvider;
        }
    }
}
