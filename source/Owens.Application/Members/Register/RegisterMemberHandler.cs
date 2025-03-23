// <copyright file="RegisterMemberHandler.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using MediatorBuddy;
using Owens.Application.Members.Common;
using Owens.Application.Users.Common;

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
            var member = MemberFactory.Member(request);

            var userInformation = UserFactory.UserInformation(request);

            var result = await _memberRepository.AddMember(member, userInformation, cancellationToken);

            if (result < 1)
            {
                return OperationCouldNotBeCompleted();
            }

            var response = MemberFactory.RegisterMemberResponse(member);

            return Success(response);
        }
    }
}
