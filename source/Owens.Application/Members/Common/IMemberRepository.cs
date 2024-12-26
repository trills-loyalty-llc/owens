// <copyright file="IMemberRepository.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using Owens.Domain.Members;

namespace Owens.Application.Members.Common
{
    /// <summary>
    /// Interface for interacting with <see cref="Member"/> persistence.
    /// </summary>
    public interface IMemberRepository
    {
        /// <summary>
        /// Adds a member to persistence.
        /// </summary>
        /// <param name="member">A <see cref="Member"/>.</param>
        /// <param name="password">The password for the member.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task AddMember(Member member, string password);
    }
}
