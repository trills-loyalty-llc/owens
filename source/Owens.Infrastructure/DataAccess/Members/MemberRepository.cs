// <copyright file="MemberRepository.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using ClearDomain.GuidPrimary;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Owens.Application.Members.Common;
using Owens.Domain.Members;
using Owens.Infrastructure.DataAccess.Common;
using Owens.Infrastructure.Identity.Models;

namespace Owens.Infrastructure.DataAccess.Members
{
    /// <inheritdoc cref="IMemberRepository" />
    public class MemberRepository : BaseRepository<Member>, IMemberRepository
    {
        private readonly UserManager<User> _userManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="MemberRepository"/> class.
        /// </summary>
        /// <param name="publisher">An instance of the <see cref="IPublisher"/> interface.</param>
        /// <param name="applicationContext">An instance of the <see cref="ApplicationContext"/> class.</param>
        /// <param name="userManager">An instance of the <see cref="UserManager{TUser}"/> class.</param>
        public MemberRepository(IPublisher publisher, ApplicationContext applicationContext, UserManager<User> userManager)
            : base(publisher, applicationContext)
        {
            _userManager = userManager;
        }

        /// <inheritdoc/>
        public async Task<bool> AddMember(Member member, string email, string username, string password, CancellationToken cancellationToken)
        {
            var user = new User
            {
                Id = member.Id,
                UserName = username,
                Email = email,
            };

            await _userManager.CreateAsync(user, password);

            await ApplicationContext.Members.AddAsync(member, cancellationToken);

            var result = await ApplicationContext.SaveChangesAsync(cancellationToken);

            await PublishEvents(new List<IAggregateRoot> { member }, cancellationToken);

            return result > 0;
        }
    }
}
