// <copyright file="RegisterMemberRequest.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;
using MediatorBuddy;

namespace Owens.Contracts.Members.Register
{
    /// <inheritdoc />
    public class RegisterMemberRequest : IEnvelopeRequest<RegisterMemberResponse>
    {
        /// <summary>
        /// Gets the username.
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        public string UserName { get; init; } = string.Empty;

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
