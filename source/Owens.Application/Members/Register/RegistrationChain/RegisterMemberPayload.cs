// <copyright file="RegisterMemberPayload.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using ChainStrategy;
using Owens.Contracts.Members.Register;

namespace Owens.Application.Members.Register.RegistrationChain
{
    /// <inheritdoc />
    public class RegisterMemberPayload : ChainPayload
    {
        private RegisterMemberPayload(RegisterMemberRequest request)
        {
            Request = request;
        }

        /// <summary>
        /// Gets the request object.
        /// </summary>
        public RegisterMemberRequest Request { get; }

        /// <summary>
        /// Gets the member identifier.
        /// </summary>
        public Guid MemberId { get; private set; }

        /// <summary>
        /// Instantiates a new instance of the <see cref="RegisterMemberPayload"/> from a request object.
        /// </summary>
        /// <param name="request">A <see cref="RegisterMemberRequest"/> class.</param>
        /// <returns>A new <see cref="RegisterMemberPayload"/> instance.</returns>
        public static RegisterMemberPayload FromRequest(RegisterMemberRequest request)
        {
            return new RegisterMemberPayload(request);
        }

        /// <summary>
        /// Appends the member id to the payload.
        /// </summary>
        /// <param name="id">The identifier to append.</param>
        public void AppendMemberId(Guid id)
        {
            MemberId = id;
        }
    }
}
