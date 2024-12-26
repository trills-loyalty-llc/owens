// <copyright file="ContainerRegistration.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using ChainStrategy.Registration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Owens.Application.Common.Interfaces;
using Owens.Application.Members.Common;
using Owens.Infrastructure.DataAccess.Common;
using Owens.Infrastructure.DataAccess.Members;
using Owens.Infrastructure.Identity.DataAccess;

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
            services.AddMediatR(serviceConfiguration => serviceConfiguration.RegisterServicesFromAssemblies(AssemblyConstants.Infrastructure, AssemblyConstants.Application));
            services.AddChainStrategy(AssemblyConstants.Application, AssemblyConstants.Application);

            // Data Access
            services.AddDbContext<ApplicationContext>(builder => builder.UseSqlServer(configuration.GetConnectionString("Application")));
            services.AddDbContext<IdentityContext>(builder => builder.UseSqlServer(configuration.GetConnectionString("Identity")));

            services.AddTransient<IMemberRepository, MemberRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
        }
    }
}
