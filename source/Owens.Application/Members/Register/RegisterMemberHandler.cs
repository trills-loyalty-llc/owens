// <copyright file="RegisterMemberHandler.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using MediatorBuddy;
using Owens.Application.Members.Common;
using Owens.Contracts.Members.Register;
using Owens.Domain.Members;

namespace Owens.Application.Members.Register
{
    /// <inheritdoc />
    public class RegisterMemberHandler : EnvelopeHandler<RegisterMemberRequest, RegisterMemberResponse>
    {
        private readonly IMemberRepository _memberRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="RegisterMemberHandler"/> class.
        /// </summary>
        /// <param name="memberRepository">An instance of the <see cref="IMemberRepository"/>.</param>
        public RegisterMemberHandler(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        /// <inheritdoc/>
        public override async Task<IEnvelope<RegisterMemberResponse>> Handle(RegisterMemberRequest request, CancellationToken cancellationToken)
        {
            var member = new Member();

            var result = await _memberRepository.AddMember(member, request.Email, request.UserName, request.Password, cancellationToken);

            if (!result)
            {
                return OperationCouldNotBeCompleted();
            }

            return Success(new RegisterMemberResponse(member.Id));
        }
    }
}
