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
        public async Task<List<Destination>> GetDestinations(CancellationToken cancellationToken = default)
        {
            return await ExecuteGet<DestinationsResponseWrapper, List<Destination>>(new Uri("destinations", UriKind.Relative), DestinationsResponseWrapper.Default(), cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<ParkDetails> GetParkDetails(Guid id, CancellationToken cancellationToken = default)
        {
            return await ExecuteGet<ParkDetailsResponse, ParkDetails>(new Uri($"entity/{id}", UriKind.Relative), ParkDetailsResponse.Default(), cancellationToken);
        }
    }
}
