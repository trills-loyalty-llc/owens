// <copyright file="ContainerRegistration.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using ChainStrategy.Registration;
using FactoryFoundation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NMediation.Dependencies;
using Owens.Application.Attractions.Common;
using Owens.Application.Services.QueueTimes.Interfaces;
using Owens.Infrastructure.DataAccess.Attractions;
using Owens.Infrastructure.DataAccess.Common;
using Owens.Infrastructure.HealthChecks;
using Owens.Infrastructure.ServiceClients.QueueTimes.Clients;
using Polly;
using Polly.Retry;
using Polly.Timeout;
using Serilog;

namespace Owens.Infrastructure.Dependencies
{
    /// <summary>
    /// Registers all application dependencies.
    /// </summary>
    public static class ContainerRegistration
    {
        /// <summary>
        /// Common method to register all application dependencies.
        /// </summary>
        /// <param name="services">An instance of the <see cref="IServiceCollection"/> interface.</param>
        /// <param name="configuration">An instance of the <see cref="IConfiguration"/> interface.</param>
        public static void RegisterDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            // Application
            services.AddChainStrategy(AssemblyConstants.Application, AssemblyConstants.Infrastructure);
            services.AddNMediation(AssemblyConstants.Application, AssemblyConstants.Infrastructure);
            services.AddFactoryFoundation(AssemblyConstants.Application, AssemblyConstants.Infrastructure);

            // Time
            services.AddSingleton(_ => TimeProvider.System);

            // Data Access
            services.AddSqlServer<ApplicationContext>(configuration.GetConnectionString("Database"));

            services.AddTransient<IAttractionRepository, AttractionRepository>();

            // Spool up the database for rapid creation if a model was changed.
            using (var context = new ApplicationContext(new DbContextOptionsBuilder().UseSqlServer(configuration.GetConnectionString("Database")).Options))
            {
                context.Database.EnsureCreated();
            }

            // Time
            services.AddSingleton(_ => TimeProvider.System);

            // Health Checks
            services.AddHealthChecks()
                .AddDbContextCheck<ApplicationContext>()
                .AddApplicationLifecycleHealthCheck()
                .AddResourceUtilizationHealthCheck();

            services.AddTransient<IHealthCheckService, HealthCheckManager>();

            // Logging
            services.AddSerilog((serviceProvider, lc) => lc
                .ReadFrom.Services(serviceProvider)
                .ReadFrom.Configuration(configuration)
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .WriteTo.Debug());

            // Service Clients
            var policy = new ResiliencePipelineBuilder<HttpResponseMessage>()
                .AddRetry(new RetryStrategyOptions<HttpResponseMessage>())
                .AddTimeout(new TimeoutStrategyOptions())
                .Build().AsAsyncPolicy();

            services
                .AddHttpClient<IQueueTimesService, QueueTimesServiceClient>(client =>
                {
                    client.BaseAddress = new Uri("https://queue-times.com/parks/");
                }).AddPolicyHandler(policy);
        }
    }
}
