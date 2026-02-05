// <copyright file="AddOperatorResponse.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using Owens.Application.Common.Contracts;

namespace Owens.Application.Operators.AddOperator
{
    /// <inheritdoc />
    public class AddOperatorResponse : EntityResponse
    {
        /// <inheritdoc />
        public AddOperatorResponse(Guid id)
            : base(id)
        {
        }
    }
}
