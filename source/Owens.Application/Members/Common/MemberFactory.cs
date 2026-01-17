// <copyright file="MemberFactory.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using Owens.Application.Members.Register;
using Owens.Domain.Members;

namespace Owens.Application.Members.Common
{
    /// <summary>
    /// Factory methods for the <see cref="Member"/> class.
    /// </summary>
    public static class MemberFactory
    {
        /// <summary>
        /// Instantiates a user information object.
        /// </summary>
        /// <param name="request">A <see cref="RegisterMemberRequest"/> object.</param>
        /// <returns>A <see cref="Member"/> instance.</returns>
        public static Member Member(RegisterMemberRequest request)
        {
            return new Member(request.Username, request.Email);
        }
    }
}
