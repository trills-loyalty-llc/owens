// <copyright file="PasswordRequirements.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using System.Text.RegularExpressions;

namespace Owens.Infrastructure.Identity.Models
{
    /// <summary>
    /// Requirements for <see cref="User"/> passwords.
    /// </summary>
    public class PasswordRequirements
    {
        /// <summary>
        /// Gets the minimum password length for a <see cref="User"/>.
        /// </summary>
        public const int MinimumPasswordLength = 8;

        /// <summary>
        /// Gets a string for <see cref="Regex"/> that must contain at least one lowercase, one uppercase, one number, and one special character.
        /// </summary>
        public const string PasswordRegex = "^.*(?=.{8,})(?=.*[a-zA-Z])(?=.*\\d)(?=.*[!#$%&? \"]).*$";
    }
}
