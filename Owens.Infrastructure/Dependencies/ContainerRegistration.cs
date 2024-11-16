// <copyright file="ContainerRegistration.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using Microsoft.Extensions.DependencyInjection;

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
        public static void RegisterDependencies(this IServiceCollection services)
        {
            services.AddMediatR(configuration => configuration.RegisterServicesFromAssemblies(AssemblyConstants.Infrastructure, AssemblyConstants.Application));
        }
    }
}
