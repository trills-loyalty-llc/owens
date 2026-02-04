// <copyright file="JobRegistration.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using Microsoft.Extensions.DependencyInjection;
using Owens.Infrastructure.Jobs;
using Quartz;
using Quartz.AspNetCore;

namespace Owens.Infrastructure.Dependencies
{
    /// <summary>
    /// Registration for automated jobs.
    /// </summary>
    public static class JobRegistration
    {
        /// <summary>
        /// Registers all jobs for the application.
        /// </summary>
        /// <param name="services">An instance of the <see cref="IServiceCollection"/> interface.</param>
        public static void RegisterJobs(this IServiceCollection services)
        {
            services.AddQuartz(configurator =>
            {
                configurator.AddJob<WaitTimesJob>(jobConfigurator => jobConfigurator.WithIdentity(WaitTimesJob.WaitTimesJobKey));

                const int queueTimesInterval = 5;
                configurator.AddTrigger(triggerConfigurator => triggerConfigurator
                    .ForJob(WaitTimesJob.WaitTimesJobKey)
                    .WithSimpleSchedule(builder => builder.WithIntervalInMinutes(queueTimesInterval).RepeatForever()));
            });

            services.AddQuartzServer(options => options.WaitForJobsToComplete = true);
        }
    }
}
