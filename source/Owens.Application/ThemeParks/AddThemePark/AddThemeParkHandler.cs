// <copyright file="AddThemeParkHandler.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using FactoryFoundation;
using Owens.Application.Common.Mediation;
using Owens.Application.ThemeParks.Common;
using Owens.Domain.ThemeParks;

namespace Owens.Application.ThemeParks.AddThemePark
{
    /// <inheritdoc />
    public class AddThemeParkHandler : EnvelopeHandler<AddThemeParkRequest, AddThemeParkResponse>
    {
        private readonly ITranslator _translator;
        private readonly IThemeParkRepository _themeParkRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddThemeParkHandler"/> class.
        /// </summary>
        /// <param name="translator">An instance of the <see cref="ITranslator"/> interface.</param>
        /// <param name="themeParkRepository">An instance of the <see cref="IThemeParkRepository"/> interface.</param>
        public AddThemeParkHandler(ITranslator translator, IThemeParkRepository themeParkRepository)
        {
            _translator = translator;
            _themeParkRepository = themeParkRepository;
        }

        /// <inheritdoc/>
        public override async Task<Envelope<AddThemeParkResponse>> Handle(AddThemeParkRequest payload, CancellationToken cancellationToken)
        {
            var envelope = _translator.Translate<AddThemeParkRequest, ValidationEnvelope<ThemePark>>(payload);

            if (envelope.IsInvalid)
            {
                return ValidationFailed();
            }

            var result = await _themeParkRepository.AddObject(envelope.Entity, cancellationToken);

            if (result.Failed)
            {
                return OperationFailed();
            }

            var response = _translator.Translate<ThemePark, AddThemeParkResponse>(envelope.Entity);

            return Success(response);
        }
    }
}
