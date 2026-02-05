// <copyright file="AddAttractionRequest.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using Owens.Application.Common.Mediation;
using Owens.Domain.Attractions;
using System.ComponentModel.DataAnnotations;

namespace Owens.Application.Attractions.AddAttraction
{
    /// <inheritdoc />
    public class AddAttractionRequest : IEnvelopePayload<AddAttractionResponse>
    {
        /// <summary>
        /// Gets the description.
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        public string Description { get; init; } = string.Empty;

        /// <summary>
        /// Gets the external id.
        /// </summary>
        [Range(0, 9999)]
        public int ExternalId { get; init; }

        /// <summary>
        /// Gets the attraction type.
        /// </summary>
        [Range(0, 7)]
        public AttractionType AttractionType { get; init; }

        /// <summary>
        /// Gets the external scheduling identifier.
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        public Guid ExternalSchedulingId { get; init; }
    }
}
