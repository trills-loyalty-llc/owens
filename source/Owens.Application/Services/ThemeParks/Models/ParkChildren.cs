// <copyright file="ParkChildren.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using ClearDomain.GuidPrimary;
using Owens.Domain.Common;

namespace Owens.Application.Services.ThemeParks.Models
{
    /// <summary>
    /// Synonymous with an attraction.
    /// </summary>
    public class ParkChildren : IEntity, IDescription
    {
        /// <inheritdoc/>
        public Guid Id { get; init; }

        /// <inheritdoc/>
        public string Description { get; init; } = string.Empty;
    }
}
