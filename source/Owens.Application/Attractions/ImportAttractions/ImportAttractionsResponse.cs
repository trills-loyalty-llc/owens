// <copyright file="ImportAttractionsResponse.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using Owens.Application.Common.Contracts;

namespace Owens.Application.Attractions.ImportAttractions
{
    /// <summary>
    /// Response for the <see cref="ImportAttractionsRequest"/> object.
    /// </summary>
    public class ImportAttractionsResponse : EntityResponse
    {
        /// <inheritdoc />
        public ImportAttractionsResponse(Guid id)
            : base(id)
        {
        }
    }
}
