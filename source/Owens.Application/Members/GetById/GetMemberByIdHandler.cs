// <copyright file="GetMemberByIdHandler.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using MediatorBuddy;
using Owens.Contracts.Members.GetById;

namespace Owens.Application.Members.GetById
{
    /// <inheritdoc />
    public class GetMemberByIdHandler : EnvelopeHandler<GetMemberByIdRequest, GetMemberByIdResponse>
    {
        /// <inheritdoc/>
        public override Task<IEnvelope<GetMemberByIdResponse>> Handle(GetMemberByIdRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult(Success(new GetMemberByIdResponse(Guid.NewGuid())));
        }
    }
}
