// <copyright file="EntityParentResult.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

namespace Owens.Infrastructure.ServiceClients.ThemeParks.Models
{
    /// <summary>
    /// The parent result for a parent theme park.
    /// </summary>
    public class EntityParentResult
    {
        /// <summary>
        /// Gets the children of the parent theme park.
        /// </summary>
        public IEnumerable<EntityChildResult> Children { get; init; } = Enumerable.Empty<EntityChildResult>();
    }
}
