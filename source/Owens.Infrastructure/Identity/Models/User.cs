// <copyright file="User.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Identity;
using Owens.Domain.Users;

namespace Owens.Infrastructure.Identity.Models
{
    /// <inheritdoc />
    public sealed class User : IdentityUser<Guid>
    {
        /// <inheritdoc />
        public User()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        /// <param name="id">The identifier for the user.</param>
        /// <param name="email">The email for the user.</param>
        /// <param name="username">The username for the user.</param>
        public User(Guid id, string email, string username)
            : base(username)
        {
            Id = id;
            Email = email;
        }

        /// <summary>
        /// Instantiates a User object.
        /// </summary>
        /// <param name="id">The user identifier.</param>
        /// <param name="userInformation">A <see cref="UserInformation"/> object.</param>
        /// <returns>A <see cref="User"/> object.</returns>
        public static User FromInformation(Guid id, UserInformation userInformation)
        {
            return new User(id, userInformation.Email, userInformation.Username);
        }
    }
}
