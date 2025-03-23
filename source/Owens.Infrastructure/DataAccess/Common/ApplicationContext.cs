﻿// <copyright file="ApplicationContext.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Owens.Domain.Members;
using Owens.Infrastructure.Common.Logging.Common;
using Owens.Infrastructure.Dependencies;
using Owens.Infrastructure.Identity.Models;

namespace Owens.Infrastructure.DataAccess.Common
{
    /// <inheritdoc />
    public sealed class ApplicationContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationContext"/> class.
        /// </summary>
        /// <param name="options">An instance of the <see cref="DbContextOptions"/> class.</param>
        public ApplicationContext(DbContextOptions options)
            : base(options)
        {
            Database.EnsureCreated();

            Members = Set<Member>();
            Logs = Set<Log>();
        }

        /// <summary>
        /// Gets the program members.
        /// </summary>
        public DbSet<Member> Members { get; }

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
