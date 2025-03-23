// <copyright file="GetMemberByIdHandler.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using MediatorBuddy;
using Owens.Application.Members.Common;

namespace Owens.Application.Members.GetById
{
    /// <inheritdoc />
    public class GetMemberByIdHandler : EnvelopeHandler<GetMemberByIdRequest, GetMemberByIdResponse>
    {
        private readonly IMemberRepository _memberRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetMemberByIdHandler"/> class.
        /// </summary>
        /// <param name="memberRepository">An instance of the <see cref="IMemberRepository"/> interface.</param>
        public GetMemberByIdHandler(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        /// <inheritdoc/>
        public override async Task<IEnvelope<GetMemberByIdResponse>> Handle(GetMemberByIdRequest request, CancellationToken cancellationToken)
        {
            var member = await _memberRepository.GetObjectById(request.Id, cancellationToken);

            if (member == null)
            {
                return EntityWasNotFound();
            }

            return Success(new GetMemberByIdResponse(member.Id));
        }
    }
}
