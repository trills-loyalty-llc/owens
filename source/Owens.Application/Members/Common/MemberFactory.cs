// <copyright file="MemberFactory.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using Owens.Application.Members.Register;
using Owens.Domain.Members;

namespace Owens.Application.Members.Common
{
    /// <summary>
    /// Factory functions for the <see cref="Member"/> class.
    /// </summary>
    public static class MemberFactory
    {
        /// <summary>
        /// Instantiates a member from a request object.
        /// </summary>
        /// <param name="request">A <see cref="RegisterMemberRequest"/> class.</param>
        /// <returns>A <see cref="Member"/> instance.</returns>
        public static Member Member(RegisterMemberRequest request)
        {
            return new Member();
        }

        /// <summary>
        /// Instantiates a register member response from an entity.
        /// </summary>
        /// <param name="member">A <see cref="Member"/> class.</param>
        /// <returns>A <see cref="RegisterMemberResponse"/> instance.</returns>
        public static RegisterMemberResponse RegisterMemberResponse(Member member)
        {
            return new RegisterMemberResponse(member.Id);
        }
    }
}
