// <copyright file="IMemberRepository.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using Owens.Application.Common.DataAccess;
using Owens.Domain.Members;
using Owens.Domain.Users;

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
        /// <param name="userInformation">A <see cref="UserInformation"/> class.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<int> AddMember(Member member, UserInformation userInformation, CancellationToken cancellationToken);
    }
}
