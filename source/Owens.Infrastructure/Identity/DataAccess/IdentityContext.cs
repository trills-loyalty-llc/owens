// <copyright file="IdentityContext.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Owens.Infrastructure.Identity.Models;

namespace Owens.Infrastructure.Identity.DataAccess
{
    /// <inheritdoc />
    public sealed class IdentityContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IdentityContext"/> class.
        /// </summary>
        /// <param name="options">An instance of the <see cref="DbContextOptions"/> class.</param>
        public IdentityContext(DbContextOptions<IdentityContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
