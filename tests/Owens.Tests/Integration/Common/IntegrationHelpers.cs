// <copyright file="IntegrationHelpers.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
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
        /// Gets the Identity Context.
        /// </summary>
        /// <returns>A <see cref="IdentityContext"/> instance.</returns>
        public static IdentityContext GetTestIdentityContext()
        {
            return GetProvider().GetRequiredService<IdentityContext>();
        }

        /// <summary>
        /// Gets the Application Context.
        /// </summary>
        /// <returns>A <see cref="ApplicationContext"/> instance.</returns>
        public static ApplicationContext GetTestApplicationContext()
        {
            return GetProvider().GetRequiredService<ApplicationContext>();
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
