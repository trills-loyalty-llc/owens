// <copyright file="JobRegistration.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using Microsoft.Extensions.DependencyInjection;
using Owens.Infrastructure.Jobs;
using Owens.Infrastructure.Jobs.Scheduling;
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
                configurator.AddJob<QueueStatusJob>(jobConfigurator => jobConfigurator.WithIdentity(QueueStatusJob.QueueStatusJobKey));
                configurator.AddJob<WeatherJob>(jobConfigurator => jobConfigurator.WithIdentity(WeatherJob.WeatherJobKey));
                configurator.AddJob<ParkScheduleJob>(jobConfigurator => jobConfigurator.WithIdentity(ParkScheduleJob.ParkScheduleJobKey));

                const int fiveMinutes = 5;
                const int onceADay = 24;

                configurator.AddTrigger(triggerConfigurator => triggerConfigurator
                   .ForJob(QueueStatusJob.QueueStatusJobKey)
                   .WithSimpleSchedule(builder => builder.WithIntervalInMinutes(fiveMinutes).RepeatForever()));

                configurator.AddTrigger(triggerConfigurator => triggerConfigurator
                    .ForJob(WeatherJob.WeatherJobKey)
                    .WithSimpleSchedule(builder => builder.WithIntervalInMinutes(fiveMinutes).RepeatForever()));

                configurator.AddTrigger(triggerConfigurator => triggerConfigurator
                    .ForJob(ParkScheduleJob.ParkScheduleJobKey)
                    .WithSimpleSchedule(builder => builder.WithIntervalInHours(onceADay).RepeatForever()));
            });

            services.AddQuartzServer(options => options.WaitForJobsToComplete = true);
        }
    }
}
