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
            var buzz = new Attraction(Guid.Parse("72c7343a-f7fb-4f66-95df-c91016de7338"), "Buzz Lightyear's Space Ranger Spin", AttractionType.Dark);
            var dwarfsMineTrains = new Attraction(Guid.Parse("9d4d5229-7142-44b6-b4fb-528920969a2c"), "Seven Dwarfs Mine Trains", AttractionType.RollerCoaster);
            var tron = new Attraction(Guid.Parse("5a43d1a7-ad53-4d25-abfe-25625f0da304"), "Tron Lightcycle Run", AttractionType.RollerCoaster);

            var magicKingdom = new ThemePark(Guid.Parse("75ea578a-adc8-4116-a54d-dccb60765ef9"), "Magic Kingdom", new Location(28.4160036778, -81.5811902834, EasternTime));
            magicKingdom.AppendAttraction(teaCups);
            magicKingdom.AppendAttraction(buzz);
            magicKingdom.AppendAttraction(dwarfsMineTrains);
            magicKingdom.AppendAttraction(tron);

            var disneyWorld = new ResortArea("Walt Disney World");
            disneyWorld.AppendThemePark(magicKingdom);

            var disney = new ResortOperator("Disney Parks");
            disney.AppendResortArea(disneyWorld);

            var universal = new ResortOperator("Universal Parks & Destinations");

            return new List<ResortOperator>
            {
                disney,
                universal,
            };
        }
    }
}
