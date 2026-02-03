// <copyright file="ContainerRegistration.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using ChainStrategy.Registration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NMediation.Dependencies;
using Owens.Infrastructure.DataAccess.Common;
using Owens.Infrastructure.HealthChecks;
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
            services.AddSerilog((serviceProvider, lc) => lc
                .ReadFrom.Services(serviceProvider)
                .ReadFrom.Configuration(configuration)
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .WriteTo.Debug());
        }
    }
}
