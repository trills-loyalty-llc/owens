// <copyright file="ImportResortAreasHandler.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using FactoryFoundation;
using NMediation.Abstractions;
using Owens.Application.Attractions.Common;
using Owens.Application.Common.Mediation;
using Owens.Application.Operators.Common;
using Owens.Application.Services.ThemeParks.Interfaces;
using Owens.Application.Services.ThemeParks.Models;
using Owens.Application.ThemeParks.Common;
using Owens.Domain.Attractions;
using Owens.Domain.Operators;
using Owens.Domain.ThemeParks;

namespace Owens.Application.Operators.ImportResortAreas
{
    /// <inheritdoc />
    public class ImportResortAreasHandler : EnvelopeHandler<ImportResortAreasRequest, Empty>
    {
        private readonly ITranslator _translator;
        private readonly IThemeParksService _themeParksService;
        private readonly IOperatorRepository _operatorRepository;
        private readonly IAttractionRepository _attractionRepository;
        private readonly IThemeParkRepository _themeParkRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ImportResortAreasHandler"/> class.
        /// </summary>
        /// <param name="translator">An instance of the <see cref="ITranslator"/> interface.</param>
        /// <param name="themeParksService">An instance of the <see cref="IThemeParksService"/> interface.</param>
        /// <param name="operatorRepository">An instance of the <see cref="IOperatorRepository"/> interface.</param>
        /// <param name="attractionRepository">An instance of the <see cref="IAttractionRepository"/> interface.</param>
        /// <param name="themeParkRepository">An instance of the <see cref="IThemeParkRepository"/> interface.</param>
        public ImportResortAreasHandler(ITranslator translator, IThemeParksService themeParksService, IOperatorRepository operatorRepository, IAttractionRepository attractionRepository, IThemeParkRepository themeParkRepository)
        {
            _translator = translator;
            _themeParksService = themeParksService;
            _operatorRepository = operatorRepository;
            _attractionRepository = attractionRepository;
            _themeParkRepository = themeParkRepository;
        }

        /// <inheritdoc/>
        public override async Task<Envelope<Empty>> Handle(ImportResortAreasRequest payload, CancellationToken cancellationToken)
        {
            var allOperators = await _operatorRepository.GetAllObjects(cancellationToken);

            var destinations = await _themeParksService.GetDestinations(cancellationToken);

            foreach (var destination in destinations)
            {
                var matchedOperator = allOperators.FirstOrDefault(resortOperator => destination.Description.Contains(resortOperator.Description));

                if (matchedOperator != null)
                {
                    var resortArea = _translator.Translate<Destination, ResortArea>(destination);

                    matchedOperator.AppendResortArea(resortArea);

                    await _operatorRepository.UpdateObject(matchedOperator, cancellationToken);

                    foreach (var park in destination.Parks)
                    {
                        var parkDetails = await _themeParksService.GetParkDetails(park.Id, cancellationToken);

                        var themePark = _translator.Translate<ParkDetails, ThemePark>(parkDetails);

                        await _themeParkRepository.AddObject(themePark, cancellationToken);

                        var children = await _themeParksService.GetParkChildren(park.Id, cancellationToken);

                        foreach (var child in children)
                        {
                            var attraction = _translator.Translate<ParkChildren, Attraction>(child);

                            await _attractionRepository.AddObject(attraction, cancellationToken);
                        }
                    }
                }
            }

            return Success(Empty.Instance);
        }
    }
}
