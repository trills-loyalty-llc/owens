// <copyright file="RegisterMemberRequest.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;
using MediatR;

namespace Owens.Contracts.Members.Register
{
    /// <inheritdoc />
    public class RegisterMemberRequest : IRequest<RegisterMemberResponse>
    {
        /// <summary>
        /// Gets the username.
        /// </summary>
        [Required]
        public string UserName { get; init; } = string.Empty;

        /// <summary>
        /// Gets the email.
        /// </summary>
        [EmailAddress]
        public string Email { get; init; } = string.Empty;

        /// <summary>
        /// Gets the password.
        /// </summary>
        [Required]
        public string Password { get; init; } = string.Empty;
    }
}
