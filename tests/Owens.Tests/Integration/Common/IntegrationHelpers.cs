// <copyright file="IntegrationHelpers.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Owens.Infrastructure.DataAccess.Common;
using Owens.Infrastructure.Dependencies;

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
        /// Clears all database tables.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        public static async Task ClearTablesAsync()
        {
            await using (var context = new ApplicationContext(GetApplicationOptions()))
            {
                await context.SaveChangesAsync();
            }
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
                collection.AddAuthenticationDependencies(configuration);

                var provider = collection.BuildServiceProvider();
                _serviceProvider = provider;

                return provider;
            }

            return _serviceProvider;
        }
    }
}
