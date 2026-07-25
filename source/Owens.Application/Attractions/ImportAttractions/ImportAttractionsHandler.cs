// <copyright file="ImportAttractionsHandler.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using Owens.Application.Common.Mediation;
using Owens.Application.Services.ThemeParks.Interfaces;
using Owens.Application.ThemeParks.Common;

namespace Owens.Application.Attractions.ImportAttractions
{
    /// <inheritdoc />
    public class ImportAttractionsHandler : EnvelopeHandler<ImportAttractionsRequest, ImportAttractionsResponse>
    {
        private readonly IThemeParksService _themeParksService;
        private readonly IThemeParkRepository _themeParkRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ImportAttractionsHandler"/> class.
        /// </summary>
        /// <param name="themeParksService">An instance of the <see cref="IThemeParksService"/> interface.</param>
        /// <param name="themeParkRepository">An instance of the <see cref="IThemeParkRepository"/> interface.</param>
        public ImportAttractionsHandler(IThemeParksService themeParksService, IThemeParkRepository themeParkRepository)
        {
            _themeParksService = themeParksService;
            _themeParkRepository = themeParkRepository;
        }

        /// <inheritdoc/>
        public override async Task<Envelope<ImportAttractionsResponse>> Handle(ImportAttractionsRequest payload, CancellationToken cancellationToken)
        {
            var themePark = await _themeParkRepository.GetObjectById(payload.ThemeParkId, cancellationToken);

            if (themePark == null)
            {
                return OperationFailed();
            }

            var themeParkParent = await _themeParksService.GetThemeParkChildren(payload.ThemeParkId, cancellationToken);

            foreach (var attraction in themeParkParent.Children)
            {
                themePark.AppendAttraction(attraction);
            }

            await _themeParkRepository.UpdateObject(themePark, cancellationToken);

            return Success(new ImportAttractionsResponse(payload.ThemeParkId));
        }
    }
}
