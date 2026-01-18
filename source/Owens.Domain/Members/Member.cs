// <copyright file="Member.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using ClearDomain.Identity.GuidPrimary;

namespace Owens.Domain.Members
{
    /// <inheritdoc />
    public sealed class Member : ClearDomainIdentityUser
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Member"/> class.
        /// </summary>
        /// <param name="userName">The userName for the member.</param>
        /// <param name="email">The email used for registration.</param>
        public Member(string userName, string email)
        {
            UserName = userName;
            Email = email;
            MemberStatus = MemberStatus.Novice;
        }

        /// <summary>
        /// Gets the current status of the member.
        /// </summary>
        public MemberStatus MemberStatus { get; }
    }
}
