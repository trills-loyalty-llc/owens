// <copyright file="GetMemberByIdHandler.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using MediatR;
using Owens.Contracts.Members.GetById;

namespace Owens.Application.Members.GetById
{
    /// <inheritdoc />
    public class GetMemberByIdHandler : IRequestHandler<GetMemberByIdRequest, GetMemberByIdResponse>
    {
        /// <inheritdoc />
        public Task<GetMemberByIdResponse> Handle(GetMemberByIdRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new GetMemberByIdResponse(Guid.NewGuid()));
        }
    }
}
