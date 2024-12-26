﻿// <copyright file="ContainerRegistration.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Owens.Application.Members.Common;
using Owens.Infrastructure.DataAccess.Common;
using Owens.Infrastructure.DataAccess.Members;

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
            services.AddMediatR(serviceConfiguration => serviceConfiguration.RegisterServicesFromAssemblies(AssemblyConstants.Infrastructure, AssemblyConstants.Application));

            services.AddDbContext<ApplicationContext>(builder => builder.UseSqlServer(configuration.GetConnectionString("Database")));

            services.AddTransient<IMemberRepository, MemberRepository>();
        }
    }
}
