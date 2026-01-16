// <copyright file="ContainerRegistration.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using ChainStrategy.Registration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Owens.Infrastructure.DataAccess.Common;
using Owens.Infrastructure.DataAccess.Logging;
using Owens.Infrastructure.HealthChecks;
using Owens.Infrastructure.Logging.Common;
using Owens.Infrastructure.Logging.Services;
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
            services.AddChainStrategy(AssemblyConstants.Application, AssemblyConstants.Application);

            // Data Access
            services.AddSqlServer<ApplicationContext>(configuration.GetConnectionString("Database"));

            // Time
            services.AddSingleton(_ => TimeProvider.System);

            // Health Checks
            services.AddHealthChecks()
                .AddDbContextCheck<ApplicationContext>()
                .AddApplicationLifecycleHealthCheck()
                .AddResourceUtilizationHealthCheck();

            services.AddTransient<IHealthCheckService, HealthCheckManager>();

            // Logging
            services.AddTransient<ILoggingService, LoggingService>();
            services.AddTransient<ILogRepository, LogRepository>();

            services.AddSerilog((serviceProvider, lc) => lc
                .ReadFrom.Configuration(configuration)
                .ReadFrom.Services(serviceProvider)
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .WriteTo.Debug());
        }
    }
}
