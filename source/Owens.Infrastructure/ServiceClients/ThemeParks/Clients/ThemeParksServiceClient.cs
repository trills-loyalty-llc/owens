// <copyright file="ThemeParksServiceClient.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using FactoryFoundation;
using Microsoft.Extensions.Logging;
using Owens.Application.Services.ThemeParks.Interfaces;
using Owens.Domain.Attractions;
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
        public async Task<QueueStatus> GetCurrentStatus(Guid id, CancellationToken cancellationToken = default)
        {
            return await ExecuteGet<EntityResult, QueueStatus>(new Uri($"entity/{id}/live", UriKind.Relative), new EntityResult(), cancellationToken);
        }
    }
}
