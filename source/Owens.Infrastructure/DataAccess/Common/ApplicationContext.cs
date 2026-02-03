// <copyright file="ApplicationContext.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Owens.Domain.Attractions;
using Owens.Domain.Members;
using Owens.Domain.Operators;
using Owens.Domain.ThemeParks;
using Owens.Infrastructure.Dependencies;
using Owens.Infrastructure.Logging.Common;

namespace Owens.Infrastructure.DataAccess.Common
{
    /// <inheritdoc />
    public sealed class ApplicationContext : IdentityDbContext<Member, IdentityRole<Guid>, Guid>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationContext"/> class.
        /// </summary>
        /// <param name="options">An instance of the <see cref="DbContextOptions"/> class.</param>
        public ApplicationContext(DbContextOptions options)
            : base(options)
        {
            Database.EnsureCreated();

            Operators = Set<ResortOperator>();
            ThemeParks = Set<ThemePark>();
            Attractions = Set<Attraction>();
            Logs = Set<Log>();
        }

        /// <summary>
        /// Gets the operators set.
        /// </summary>
        public DbSet<ResortOperator> Operators { get; }

        /// <summary>
        /// Gets the theme parks set.
        /// </summary>
        public DbSet<ThemePark> ThemeParks { get; }

        /// <summary>
        /// Gets the attractions set.
        /// </summary>
        public DbSet<Attraction> Attractions { get; }

        /// <summary>
        /// Gets the application logs.
        /// </summary>
        public DbSet<Log> Logs { get; }

        /// <inheritdoc/>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(AssemblyConstants.Infrastructure);
        }
    }
}
