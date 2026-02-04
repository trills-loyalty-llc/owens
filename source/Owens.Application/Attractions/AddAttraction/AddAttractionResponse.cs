// <copyright file="AddAttractionResponse.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using Owens.Application.Common.Contracts;

namespace Owens.Application.Attractions.AddAttraction
{
    /// <inheritdoc />
    public class AddAttractionResponse : EntityResponse
    {
        /// <inheritdoc />
        public AddAttractionResponse(Guid id)
            : base(id)
        {
        }
    }
}
