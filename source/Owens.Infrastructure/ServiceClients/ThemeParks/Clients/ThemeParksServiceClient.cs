// <copyright file="ThemeParksServiceClient.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using FactoryFoundation;
using Microsoft.Extensions.Logging;
using Owens.Application.Services.ThemeParks.Interfaces;
using Owens.Infrastructure.ServiceClients.Common;

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
    }
}
