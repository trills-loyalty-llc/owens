// <copyright file="RegisterMemberProfile.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using ChainStrategy;

namespace Owens.Application.Members.Register.RegistrationChain
{
    /// <inheritdoc />
    public class RegisterMemberProfile : ChainProfile<RegisterMemberPayload>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RegisterMemberProfile"/> class.
        /// </summary>
        public RegisterMemberProfile()
        {
            AddStep<CreateMemberHandler>()
                .AddStep<CreateUserHandler>();
        }
    }
}
