// <copyright file="GetMemberByIdRequest.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using MediatorBuddy;

namespace Owens.Application.Members.GetById
{
    /// <inheritdoc cref="IEnvelopeRequest" />
    public class GetMemberByIdRequest : EntityRequest, IEnvelopeRequest<GetMemberByIdResponse>
    {
        /// <inheritdoc />
        public GetMemberByIdRequest(Guid id)
            : base(id)
        {
        }
    }
}
