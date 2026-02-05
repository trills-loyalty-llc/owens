// <copyright file="ImportResortAreasHandler.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using NMediation.Abstractions;
using Owens.Application.Attractions.Common;
using Owens.Application.Common.Mediation;
using Owens.Application.Operators.Common;
using Owens.Application.Services.ThemeParks.Interfaces;

namespace Owens.Application.Operators.ImportResortAreas
{
    /// <inheritdoc />
    public class ImportResortAreasHandler : EnvelopeHandler<ImportResortAreasRequest, Empty>
    {
        private readonly IThemeParksService _themeParksService;
        private readonly IOperatorRepository _operatorRepository;
        private readonly IAttractionRepository _attractionRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ImportResortAreasHandler"/> class.
        /// </summary>
        /// <param name="themeParksService">An instance of the <see cref="IThemeParksService"/> interface.</param>
        /// <param name="operatorRepository">An instance of the <see cref="IOperatorRepository"/> interface.</param>
        /// <param name="attractionRepository">An instance of the <see cref="IAttractionRepository"/> interface.</param>
        public ImportResortAreasHandler(IThemeParksService themeParksService, IOperatorRepository operatorRepository, IAttractionRepository attractionRepository)
        {
            _themeParksService = themeParksService;
            _operatorRepository = operatorRepository;
            _attractionRepository = attractionRepository;
        }

        /// <inheritdoc/>
        public override async Task<Envelope<Empty>> Handle(ImportResortAreasRequest payload, CancellationToken cancellationToken)
        {
            var destinations = await _themeParksService.GetDestinations(cancellationToken);

            foreach (var destination in destinations)
            {
                var parkDetails = await _themeParksService.GetParkDetails(destination.Id, cancellationToken);
            }

            return Success(Empty.Instance);
        }
    }
}
