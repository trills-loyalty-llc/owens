// <copyright file="AttractionFactory.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using FactoryFoundation;
using Owens.Application.Attractions.AddAttraction;
using Owens.Domain.Attractions;

namespace Owens.Application.Attractions.Common
{
    /// <summary>
    /// Factory for attractions.
    /// </summary>
    public class AttractionFactory :
        ICanTranslate<AddAttractionRequest, ValidationEnvelope<Attraction>>,
        ICanTranslate<Attraction, AddAttractionResponse>
    {
        /// <inheritdoc/>
        public ValidationEnvelope<Attraction> TranslateTo(AddAttractionRequest initial)
        {
            return FactoryHelpers.TryCreateValidate(() => new Attraction(
                    initial.Description,
                    initial.AttractionType));
        }

        /// <inheritdoc/>
        public AddAttractionResponse TranslateTo(Attraction initial)
        {
            return new AddAttractionResponse(initial.Id);
        }
    }
}
