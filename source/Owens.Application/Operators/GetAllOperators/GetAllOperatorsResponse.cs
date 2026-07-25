// <copyright file="GetAllOperatorsResponse.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using Owens.Application.Common.Contracts;
using Owens.Application.Operators.Common;

namespace Owens.Application.Operators.GetAllOperators
{
    /// <inheritdoc />
    public class GetAllOperatorsResponse : AllEntitiesResponse<OperatorResponse>
    {
        /// <inheritdoc />
        public GetAllOperatorsResponse(IEnumerable<OperatorResponse> entities)
            : base(entities)
        {
        }
    }
}
