// <copyright file="MemberStatus.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

namespace Owens.Domain.Members
{
    /// <summary>
    /// Denotes the level of membership for a user.
    /// </summary>
    public enum MemberStatus
    {
        /// <summary>
        /// Akin to a base registered user.
        /// </summary>
        Novice = 0,

        /// <summary>
        /// The first level of membership for a user.
        /// </summary>
        Seeker = 1,

        /// <summary>
        /// The second level of membership for a user.
        /// </summary>
        Enthusiast = 2,
    }
}
