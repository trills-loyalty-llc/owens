// <copyright file="CreateMemberHandler.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using ChainStrategy;
using Owens.Application.Members.Common;
using Owens.Domain.Members;

namespace Owens.Application.Members.Register.RegistrationChain
{
    /// <inheritdoc />
    public class CreateMemberHandler : ChainHandler<RegisterMemberPayload>
    {
        private readonly IMemberRepository _memberRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateMemberHandler"/> class.
        /// </summary>
        /// <param name="handler">The next <see cref="IChainHandler{TPayload}"/> handler.</param>
        /// <param name="memberRepository">An instance of the <see cref="IMemberRepository"/> interface.</param>
        public CreateMemberHandler(IChainHandler<RegisterMemberPayload>? handler, IMemberRepository memberRepository)
            : base(handler)
        {
            _memberRepository = memberRepository;
        }

        /// <inheritdoc/>
        public override async Task<RegisterMemberPayload> DoWork(RegisterMemberPayload payload, CancellationToken cancellationToken)
        {
            var member = new Member();

            var result = await _memberRepository.AddObject(member, cancellationToken);

            if (!result)
            {
                payload.Faulted();
            }

            payload.AppendMemberId(member.Id);

            return payload;
        }
    }
}
