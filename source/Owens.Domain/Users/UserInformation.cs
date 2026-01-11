// <copyright file="UserInformation.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using FluentValidation;

namespace Owens.Domain.Users
{
    /// <summary>
    /// Represents an intermediate state of a User during the registration process.
    /// </summary>
    public class UserInformation
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserInformation"/> class.
        /// </summary>
        /// <param name="email">The user email.</param>
        /// <param name="username">The username.</param>
        /// <param name="password">The user password.</param>
        public UserInformation(string email, string username, string password)
        {
            Email = email;
            Username = username;
            Password = password;

            new UserInformationValidator().ValidateAndThrow(this);
        }

        /// <summary>
        /// Gets the user email.
        /// </summary>
        public string Email { get; }

        /// <summary>
        /// Gets the username.
        /// </summary>
        public string Username { get; }

        /// <summary>
        /// Gets the user password.
        /// </summary>
        public string Password { get; }
    }
}
