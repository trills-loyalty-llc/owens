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
        /// Initializes a new instance of the <see cref="Member"/> class.
        /// </summary>
        /// <param name="id">The member identifier.</param>
        /// <param name="userName">The userName of the member.</param>
        /// <param name="email">The email of the member.</param>
        /// <param name="status">The status of the member.</param>
        public Member(Guid id, string userName, string email, MemberStatus status)
        {
            Id = id;
            UserName = userName;
            Email = email;
            MemberStatus = status;
        }

        /// <summary>
        /// Gets the current status of the member.
        /// </summary>
        public MemberStatus MemberStatus { get; }
    }
}
