// <copyright file="EntityChildResult.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

namespace Owens.Infrastructure.ServiceClients.ThemeParks.Models
{
    /// <summary>
    /// The entity result for a theme park child.
    /// </summary>
    public class EntityChildResult
    {
        /// <summary>
        /// Gets the identifier of the entity.
        /// </summary>
        public Guid Id { get; init; }

        /// <summary>
        /// Gets the child name.
        /// </summary>
        public string Name { get; init; } = string.Empty;

        /// <summary>
        /// Gets a combination external identifier and external type.
        /// </summary>
        public string ExternalId { get; init; } = string.Empty;
    }
}
