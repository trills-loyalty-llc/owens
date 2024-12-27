// <copyright file="ApplicationContext.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Owens.Domain.Members;
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
        }

        /// <summary>
        /// Gets the members dbSet.
        /// </summary>
        public DbSet<Member> Members { get; }

        /// <inheritdoc/>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(AssemblyConstants.Infrastructure);
        }
    }
}
