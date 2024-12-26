// <copyright file="GetMemberByIdResponse.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using Owens.Contracts.Common;

namespace Owens.Contracts.Members.GetById
{
    /// <inheritdoc />
    public class GetMemberByIdResponse : EntityResponse
    {
        /// <inheritdoc />
        public GetMemberByIdResponse(Guid id)
            : base(id)
        {
        }
    }
}
