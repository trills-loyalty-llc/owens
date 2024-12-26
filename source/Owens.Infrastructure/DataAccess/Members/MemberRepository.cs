// <copyright file="MemberRepository.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using MediatR;
using Owens.Application.Members.Common;
using Owens.Domain.Members;
using Owens.Infrastructure.DataAccess.Common;

namespace Owens.Infrastructure.DataAccess.Members
{
    /// <inheritdoc cref="IMemberRepository" />
    public class MemberRepository : BaseRepository<Member>, IMemberRepository
    {
        /// <inheritdoc />
        public MemberRepository(IPublisher publisher, ApplicationContext applicationContext)
            : base(publisher, applicationContext)
        {
        }
    }
}
