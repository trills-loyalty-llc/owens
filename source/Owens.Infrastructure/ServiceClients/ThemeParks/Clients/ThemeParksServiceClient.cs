// <copyright file="ThemeParksServiceClient.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using FactoryFoundation;
using Microsoft.Extensions.Logging;
using Owens.Application.Services.ThemeParks.Interfaces;
using Owens.Application.Services.ThemeParks.Models;
using Owens.Infrastructure.ServiceClients.Common;
using Owens.Infrastructure.ServiceClients.ThemeParks.Models;

namespace Owens.Infrastructure.ServiceClients.ThemeParks.Clients
{
    /// <inheritdoc cref="IThemeParksService" />
    public class ThemeParksServiceClient : BaseServiceClient, IThemeParksService
    {
        /// <inheritdoc />
        public ThemeParksServiceClient(HttpClient httpClient, ITranslator translator, ILogger<BaseServiceClient> logger)
            : base(httpClient, translator, logger)
        {
        }

        /// <inheritdoc/>
        public async Task<ParkStatus> GetThemeParkStatus(Guid id, CancellationToken cancellationToken = default)
        {
            return await ExecuteGet<LiveStatusResult, ParkStatus>(new Uri($"entity/{id}/live", UriKind.Relative), new LiveStatusResult(), cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<ParkSchedule> GetThemeParkSchedule(Guid id, CancellationToken cancellationToken = default)
        {
            return await ExecuteGet<ScheduleResult, ParkSchedule>(new Uri($"entity/{id}/schedule", UriKind.Relative), new ScheduleResult(), cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<ThemeParkParent> GetThemeParkChildren(Guid id, CancellationToken cancellationToken = default)
        {
            return await ExecuteGet<EntityParentResult, ThemeParkParent>(new Uri($"entity/{id}/children", UriKind.Relative), new EntityParentResult(), cancellationToken);
        }
    }
}
