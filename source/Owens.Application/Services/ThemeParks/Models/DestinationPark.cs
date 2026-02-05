// <copyright file="DestinationPark.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using ClearDomain.GuidPrimary;
using Owens.Domain.Common;

namespace Owens.Application.Services.ThemeParks.Models
{
    /// <summary>
    /// Synonymous with a theme park. Raw data from the service client.
    /// </summary>
    public class DestinationPark : IEntity, IDescription
    {
        /// <inheritdoc/>
        public Guid Id { get; init; }

        /// <inheritdoc/>
        public string Description { get; init; } = string.Empty;
    }
}
