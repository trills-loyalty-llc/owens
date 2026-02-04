// <copyright file="SeedData.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using Owens.Domain.Attractions;

namespace Owens.Infrastructure.DataAccess.Common
{
    /// <summary>
    /// Static seed data for rapid db creation.
    /// </summary>
    public static class SeedData
    {
        /// <summary>
        /// Attraction seed data.
        /// </summary>
        /// <returns>A <see cref="IEnumerable{T}"/> of <see cref="Attraction"/>.</returns>
        public static IEnumerable<Attraction> Attractions()
        {
            return new List<Attraction>();
        }
    }
}
