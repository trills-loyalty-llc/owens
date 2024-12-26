// <copyright file="RegisterMemberResponse.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using Owens.Contracts.Common;

namespace Owens.Contracts.Members.Register
{
    /// <inheritdoc />
    public class RegisterMemberResponse : EntityResponse
    {
        /// <inheritdoc />
        public RegisterMemberResponse(Guid id)
            : base(id)
        {
        }
    }
}
