// <copyright file="IntegrationHelpers.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using MediatorBuddy;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Owens.Infrastructure.DataAccess.Common;
using Owens.Infrastructure.Dependencies;
using Owens.Infrastructure.Identity.DataAccess;
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
        /// Attempts to resolve an <see cref="IEnvelopeHandler{TRequest,TResponse}"/> instance.
        /// </summary>
        /// <typeparam name="TRequest">The type of the request object.</typeparam>
        /// <typeparam name="TResponse">The type of the response object.</typeparam>
        /// <returns>An instance of the <see cref="IEnvelopeHandler{TRequest,TResponse}"/> interface.</returns>
        public static IRequestHandler<TRequest, IEnvelope<TResponse>> GetHandler<TRequest, TResponse>()
            where TRequest : IRequest<IEnvelope<TResponse>>
        {
            return GetProvider().GetRequiredService<IRequestHandler<TRequest, IEnvelope<TResponse>>>();
        }

        /// <summary>
        /// Gets the application connection string.
        /// </summary>
        /// <returns>A connection string.</returns>
        public static string GetApplicationConnectionString()
        {
            return Environment.GetEnvironmentVariable("SQL_SERVER_CONNECTION_STRING") ??
                   "Server=.\\SQLExpress;Database=Owens.Application.Tests;Trusted_Connection=True;MultipleActiveResultSets=true;Integrated Security=True;TrustServerCertificate=true";
        }

        /// <summary>
        /// Gets the identity connection string.
        /// </summary>
        /// <returns>A connection string.</returns>
        public static string GetIdentityConnectionString()
        {
            return Environment.GetEnvironmentVariable("SQL_SERVER_CONNECTION_STRING") ??
                   "Server=.\\SQLExpress;Database=Owens.Identity.Tests;Trusted_Connection=True;MultipleActiveResultSets=true;Integrated Security=True;TrustServerCertificate=true";
        }

        /// <summary>
        /// Gets the Identity Context.
        /// </summary>
        /// <returns>A <see cref="IdentityContext"/> instance.</returns>
        public static IdentityContext GetTestIdentityContext()
        {
            var context = GetProvider().GetRequiredService<IdentityContext>();

            context.Database.EnsureCreated();

            return context;
        }

        /// <summary>
        /// Gets the Application Context.
        /// </summary>
        /// <returns>A <see cref="ApplicationContext"/> instance.</returns>
        public static ApplicationContext GetTestApplicationContext()
        {
            var context = GetProvider().GetRequiredService<ApplicationContext>();

            context.Database.EnsureCreated();

            return context;
        }

        private static IServiceProvider GetProvider()
        {
            if (_serviceProvider == null)
            {
                var collection = new ServiceCollection();

                var configuration = new ConfigurationBuilder()
                    .AddInMemoryCollection(new List<KeyValuePair<string, string?>>
                    {
                        new KeyValuePair<string, string?>("ConnectionStrings:Application", GetApplicationConnectionString()),
                        new KeyValuePair<string, string?>("ConnectionStrings:Identity", GetIdentityConnectionString()),
                    })
                    .Build();

                collection.RegisterDependencies(configuration);
                collection.AddAuthenticationDependencies(new TokenConfiguration(Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString()));

                var provider = collection.BuildServiceProvider();
                _serviceProvider = provider;

                return provider;
            }

            return _serviceProvider;
        }
    }
}
