// <copyright file="RegisterUserRequest.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;

namespace Owens.Contracts.Users.Register
{
    /// <summary>
    /// Request object registering users.
    /// </summary>
    public abstract class RegisterUserRequest
    {
        /// <summary>
        /// Gets the username.
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        public string Username { get; init; } = string.Empty;

        /// <summary>
        /// Gets the email.
        /// </summary>
        [EmailAddress]
        [Required(AllowEmptyStrings = false)]
        public string Email { get; init; } = string.Empty;

        /// <summary>
        /// Gets the password.
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        public string Password { get; init; } = string.Empty;
    }
}
