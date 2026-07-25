// <copyright file="ThemeParkParent.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using Owens.Domain.Attractions;

namespace Owens.Application.Services.ThemeParks.Models
{
    /// <summary>
    /// A theme park that contains child attractions.
    /// </summary>
    public class ThemeParkParent
    {
        /// <summary>
        /// Gets all the children fo the theme park.
        /// </summary>
        public IEnumerable<Attraction> Children { get; init; } = Enumerable.Empty<Attraction>();
    }
}
