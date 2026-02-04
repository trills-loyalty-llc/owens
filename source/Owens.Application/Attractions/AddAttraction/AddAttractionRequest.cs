// <copyright file="AddAttractionRequest.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using Owens.Application.Common.Mediation;
using Owens.Domain.Attractions;

namespace Owens.Application.Attractions.AddAttraction
{
    /// <inheritdoc />
    public class AddAttractionRequest : IEnvelopePayload<AddAttractionResponse>
    {
        /// <summary>
        /// Gets the description.
        /// </summary>
        public string Description { get; init; } = string.Empty;

        /// <summary>
        /// Gets the external id.
        /// </summary>
        public int ExternalId { get; init; }

        /// <summary>
        /// Gets the attraction type.
        /// </summary>
        public AttractionType AttractionType { get; init; }
    }
}
