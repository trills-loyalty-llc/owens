// <copyright file="ImportAttractionsRequest.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using Owens.Application.Common.Mediation;

namespace Owens.Application.Attractions.ImportAttractions
{
    /// <inheritdoc />
    public class ImportAttractionsRequest : IEnvelopePayload<ImportAttractionsResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ImportAttractionsRequest"/> class.
        /// </summary>
        /// <param name="themeParkId">The identifier of the theme park to import.</param>
        public ImportAttractionsRequest(Guid themeParkId)
        {
            ThemeParkId = themeParkId;
        }

        /// <summary>
        /// Gets the identifier of the theme park to import attractions for.
        /// </summary>
        public Guid ThemeParkId { get; }
    }
}
