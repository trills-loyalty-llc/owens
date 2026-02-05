// <copyright file="ParkDetails.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using ClearDomain.GuidPrimary;
using Owens.Domain.Common;

namespace Owens.Application.Services.ThemeParks.Models
{
    /// <summary>
    /// Details about a specified park.
    /// </summary>
    public class ParkDetails : IEntity, IDescription
    {
        /// <inheritdoc/>
        public Guid Id { get; init; }

        /// <inheritdoc/>
        public string Description { get; init; } = string.Empty;

        /// <summary>
        /// Gets the park location.
        /// </summary>
        public ParkLocation Location { get; init; } = new ParkLocation();

        /// <summary>
        /// Gets the park timeZone.
        /// </summary>
        public string TimeZone { get; init; } = string.Empty;
    }
}
