// <copyright file="AddAttractionHandler.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using FactoryFoundation;
using Owens.Application.Attractions.Common;
using Owens.Application.Common.Mediation;
using Owens.Domain.Attractions;

namespace Owens.Application.Attractions.AddAttraction
{
    /// <inheritdoc />
    public class AddAttractionHandler : EnvelopeHandler<AddAttractionRequest, AddAttractionResponse>
    {
        private readonly ITranslator _translator;
        private readonly IAttractionRepository _attractionRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddAttractionHandler"/> class.
        /// </summary>
        /// <param name="translator">An instance of the <see cref="ITranslator"/> interface.</param>
        /// <param name="attractionRepository">An instance of the <see cref="IAttractionRepository"/> interface.</param>
        public AddAttractionHandler(ITranslator translator, IAttractionRepository attractionRepository)
        {
            _translator = translator;
            _attractionRepository = attractionRepository;
        }

        /// <inheritdoc/>
        public override async Task<Envelope<AddAttractionResponse>> Handle(AddAttractionRequest payload, CancellationToken cancellationToken)
        {
            var envelope = _translator.Translate<AddAttractionRequest, ValidationEnvelope<Attraction>>(payload);

            if (envelope.IsInvalid)
            {
                return ValidationFailed();
            }

            var result = await _attractionRepository.AddObject(envelope.Entity, cancellationToken);

            if (result.Failed)
            {
                return OperationFailed();
            }

            var response = _translator.Translate<Attraction, AddAttractionResponse>(envelope.Entity);

            return Success(response);
        }
    }
}
