﻿// <copyright file="RegisterMemberHandler.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using ChainStrategy;
using MediatR;
using Owens.Application.Members.Register.RegistrationChain;
using Owens.Contracts.Members.Register;

namespace Owens.Application.Members.Register
{
    /// <inheritdoc />
    public class RegisterMemberHandler : IRequestHandler<RegisterMemberRequest, RegisterMemberResponse>
    {
        private readonly IChainFactory _chainFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="RegisterMemberHandler"/> class.
        /// </summary>
        /// <param name="chainFactory">An instance of the <see cref="IChainFactory"/> interface.</param>
        public RegisterMemberHandler(IChainFactory chainFactory)
        {
            _chainFactory = chainFactory;
        }

        /// <inheritdoc/>
        public async Task<RegisterMemberResponse> Handle(RegisterMemberRequest request, CancellationToken cancellationToken)
        {
            var payload = RegisterMemberPayload.FromRequest(request);

            var result = await _chainFactory.Execute(payload, cancellationToken);

            return new RegisterMemberResponse(Guid.NewGuid());
        }
    }
}
