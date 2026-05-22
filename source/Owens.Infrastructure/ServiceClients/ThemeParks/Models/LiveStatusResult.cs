// <copyright file="LiveStatusResult.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

namespace Owens.Infrastructure.ServiceClients.ThemeParks.Models
{
    /// <summary>
    /// Live status data from the external client.
    /// </summary>
    public class LiveStatusResult
    {
        /// <summary>
        /// Gets live data results.
        /// </summary>
        public IEnumerable<LiveDataResult> LiveData { get; init; } = Enumerable.Empty<LiveDataResult>();
    }
}
