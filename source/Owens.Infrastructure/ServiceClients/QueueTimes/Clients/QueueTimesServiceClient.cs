// <copyright file="QueueTimesServiceClient.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using FactoryFoundation;
using Microsoft.Extensions.Logging;
using Owens.Application.Services.QueueTimes.Interfaces;
using Owens.Application.Services.QueueTimes.Models;
using Owens.Infrastructure.ServiceClients.Common;
using Owens.Infrastructure.ServiceClients.QueueTimes.Models;

namespace Owens.Infrastructure.ServiceClients.QueueTimes.Clients
{
    /// <inheritdoc cref="IQueueTimesService" />
    public class QueueTimesServiceClient : BaseServiceClient, IQueueTimesService
    {
        /// <inheritdoc />
        public QueueTimesServiceClient(HttpClient httpClient, ITranslator translator, ILogger<BaseServiceClient> logger)
            : base(httpClient, translator, logger)
        {
        }

        /// <inheritdoc/>
        public async Task<List<RideQueueStatus>> GetQueueTimes(int parkId, CancellationToken cancellationToken = default)
        {
            return await ExecuteGet<QueueTimesResponseWrapper, List<RideQueueStatus>>(new Uri($"{parkId}/queue_times.json", UriKind.Relative), QueueTimesResponseWrapper.Default(), cancellationToken);
        }
    }
}
