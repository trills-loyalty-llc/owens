// <copyright file="SeedData.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using Owens.Domain.Attractions;
using Owens.Domain.Operators;
using Owens.Domain.ThemeParks;

namespace Owens.Infrastructure.Dependencies
{
    /// <summary>
    /// Initial db creation seed data.
    /// </summary>
    public static class SeedData
    {
        private static string PacificTime => "America/Los_Angeles";

        private static string CentralTime => "America/Chicago";

        private static string EasternTime => "America/New_York";

        /// <summary>
        /// Returns all operator initial data.
        /// </summary>
        /// <returns>A <see cref="List{T}"/> of operators.</returns>
        public static IEnumerable<ResortOperator> InitialSeedData()
        {
            var teaCups = new Attraction(Guid.Parse("0aae716c-af13-4439-b638-d75fb1649df3"), "Mad Tea Party", AttractionType.Trill);

            var magicKingdom = new ThemePark(Guid.Parse("75ea578a-adc8-4116-a54d-dccb60765ef9"), "Magic Kingdom", new Location(28.4160036778, -81.5811902834, EasternTime));

            var disneyWorld = new ResortArea("Walt Disney World");

            var disney = new ResortOperator("Disney Parks");
            disney.AppendResortArea(disneyWorld);

            var universal = new ResortOperator("Universal Parks & Destinations");

            return new List<ResortOperator>();
        }
    }
}
