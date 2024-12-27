// <copyright file="IMemberRepository.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using Owens.Application.Common.Interfaces;
using Owens.Domain.Members;

namespace Owens.Application.Members.Common
{
    /// <summary>
    /// Interface for interacting with <see cref="Member"/> persistence.
    /// </summary>
    public interface IMemberRepository
        : IGetObjectById<Member>
    {
        /// <summary>
        /// Adds a new member to the persistence.
        /// </summary>
        /// <param name="member">A <see cref="Member"/> class.</param>
        /// <param name="email">The member email.</param>
        /// <param name="username">The member username.</param>
        /// <param name="password">The member password.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<bool> AddMember(Member member, string email, string username, string password, CancellationToken cancellationToken);
    }
}
