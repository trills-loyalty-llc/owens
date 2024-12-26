// <copyright file="MemberRepository.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Identity;
using Owens.Application.Members.Common;
using Owens.Domain.Members;

namespace Owens.Infrastructure.DataAccess.Members
{
    /// <inheritdoc />
    public class MemberRepository : IMemberRepository
    {
        private readonly UserManager<Member> _userManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="MemberRepository"/> class.
        /// </summary>
        /// <param name="userManager">An instance of the <see cref="UserManager{TUser}"/> class.</param>
        public MemberRepository(UserManager<Member> userManager)
        {
            _userManager = userManager;
        }

        /// <inheritdoc/>
        public async Task AddMember(Member member, string password)
        {
            var result = await _userManager.CreateAsync(member, password);

            if (!result.Succeeded)
            {
                throw new Exception(nameof(member));
            }
        }
    }
}
