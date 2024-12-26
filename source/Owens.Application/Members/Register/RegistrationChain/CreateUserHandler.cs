// <copyright file="CreateUserHandler.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using ChainStrategy;
using Owens.Application.Common.Interfaces;

namespace Owens.Application.Members.Register.RegistrationChain
{
    /// <inheritdoc />
    public class CreateUserHandler : ChainHandler<RegisterMemberPayload>
    {
        private readonly IUserRepository _userRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateUserHandler"/> class.
        /// </summary>
        /// <param name="handler">The next <see cref="IChainHandler{TPayload}"/> interface.</param>
        /// <param name="userRepository">An instance of the <see cref="IUserRepository"/> interface.</param>
        public CreateUserHandler(IChainHandler<RegisterMemberPayload>? handler, IUserRepository userRepository)
            : base(handler)
        {
            _userRepository = userRepository;
        }

        /// <inheritdoc/>
        public override async Task<RegisterMemberPayload> DoWork(RegisterMemberPayload payload, CancellationToken cancellationToken)
        {
            var result = await _userRepository.AddUser(payload.MemberId, payload.Request.Email, payload.Request.Email, payload.Request.Password);

            if (!result)
            {
                payload.Faulted();
            }

            return payload;
        }
    }
}
