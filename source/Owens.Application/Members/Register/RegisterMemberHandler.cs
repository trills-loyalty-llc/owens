// <copyright file="RegisterMemberHandler.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using MediatR;
using Owens.Application.Members.Common;
using Owens.Contracts.Members.Register;
using Owens.Domain.Members;

namespace Owens.Application.Members.Register
{
    /// <inheritdoc />
    public class RegisterMemberHandler : IRequestHandler<RegisterMemberRequest, RegisterMemberResponse>
    {
        private readonly IMemberRepository _memberRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="RegisterMemberHandler"/> class.
        /// </summary>
        /// <param name="memberRepository">An instance of the <see cref="IMemberRepository"/> interface.</param>
        public RegisterMemberHandler(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        /// <inheritdoc/>
        public async Task<RegisterMemberResponse> Handle(RegisterMemberRequest request, CancellationToken cancellationToken)
        {
            var member = new Member
            {
                UserName = request.UserName,
                Email = request.Email,
                Id = Guid.NewGuid(),
            };

            await _memberRepository.AddMember(member, request.Password);

            return new RegisterMemberResponse(member.Id);
        }
    }
}
