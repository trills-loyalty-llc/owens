// <copyright file="QueueStatusJob.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using FactoryFoundation;
using Owens.Application.Attractions.Common;
using Owens.Application.Services.ThemeParks.Interfaces;
using Owens.Application.ThemeParks.Common;
using Quartz;

namespace Owens.Infrastructure.Jobs
{
    /// <inheritdoc />
    public class QueueStatusJob : IJob
    {
        /// <summary>
        /// Gets the job key.
        /// </summary>
        public static readonly JobKey QueueStatusJobKey = JobKey.Create("QueueStatusJobKey");

        private readonly ITranslator _translator;
        private readonly IThemeParksService _themeParksService;
        private readonly IAttractionRepository _attractionRepository;
        private readonly IThemeParkRepository _themeParkRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="QueueStatusJob"/> class.
        /// </summary>
        /// <param name="translator">An instance of the <see cref="ITranslator"/> interface.</param>
        /// <param name="themeParkService">An instance of the <see cref="IThemeParksService"/> interface.</param>
        /// <param name="attractionRepository">An instance of the <see cref="IAttractionRepository"/> interface.</param>
        /// <param name="themeParkRepository">An instance of the <see cref="IThemeParkRepository"/> interface.</param>
        public QueueStatusJob(ITranslator translator, IThemeParksService themeParkService, IAttractionRepository attractionRepository, IThemeParkRepository themeParkRepository)
        {
            _translator = translator;
            _themeParksService = themeParkService;
            _attractionRepository = attractionRepository;
            _themeParkRepository = themeParkRepository;
        }

        /// <inheritdoc/>
        public async Task Execute(IJobExecutionContext context)
        {
            var themeParksList = await _themeParkRepository.GetAllObjects(context.CancellationToken);

            foreach (var themePark in themeParksList)
            {
                var themeParkStatus = await _themeParksService.GetThemeParkStatus(themePark.Id, context.CancellationToken);

                foreach (var (id, status) in themeParkStatus.Attractions)
                {
                    var attraction = await _attractionRepository.GetObjectById(id, context.CancellationToken);

                    if (attraction != null)
                    {
                        attraction.AppendStatus(status);

                        await _attractionRepository.UpdateObject(attraction, context.CancellationToken);
                    }
                }
            }
        }
    }
}
