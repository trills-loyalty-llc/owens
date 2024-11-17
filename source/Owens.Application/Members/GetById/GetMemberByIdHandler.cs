// <copyright file="GetMemberByIdHandler.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using MediatR;
using Owens.Contracts.Member;
using Owens.Contracts.Member.Common;
using Owens.Domain.Members;

namespace Owens.Application.Members.GetById
{
    /// <inheritdoc />
    public class GetMemberByIdHandler : IRequestHandler<GetMemberByIdRequest, MemberResponse>
    {
        /// <inheritdoc />
        public Task<MemberResponse> Handle(GetMemberByIdRequest request, CancellationToken cancellationToken)
        {
            var customer = new Member();

            return Task.FromResult(new MemberResponse(customer.Id));
        }
    }
}
