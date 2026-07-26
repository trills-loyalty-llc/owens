// <copyright file="SeedData.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using Owens.Domain.Common;
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
            // var teaCups = new Attraction(Guid.Parse("0aae716c-af13-4439-b638-d75fb1649df3"), 80010162, "Mad Tea Party", AttractionType.Trill);
            // var buzz = new Attraction(Guid.Parse("72c7343a-f7fb-4f66-95df-c91016de7338"), 80010114, "Buzz Lightyear's Space Ranger Spin", AttractionType.Dark);
            // var dwarfsMineTrains = new Attraction(Guid.Parse("9d4d5229-7142-44b6-b4fb-528920969a2c"), 16767284, "Seven Dwarfs Mine Trains", AttractionType.RollerCoaster);
            // var tron = new Attraction(Guid.Parse("5a43d1a7-ad53-4d25-abfe-25625f0da304"), 411504498, "Tron Lightcycle Run", AttractionType.RollerCoaster);
            var magicKingdom = new ThemePark(Guid.Parse("75ea578a-adc8-4116-a54d-dccb60765ef9"), "Magic Kingdom", 80007944, new Location(28.4160036778, -81.5811902834));

            // var epcot = new ThemePark(Guid.Parse("47f90d2c-e191-4239-a466-5892ef59a88b"), "Epcot", new Location(28.3723467915183, -81.54892366079102));
            // var hollywoodStudios = new ThemePark(Guid.Parse("288747d1-8b4f-4a64-867e-ea7c9b27bad8"), "Hollywood Studios", new Location(28.358311629500708, -81.5588800206543));
            // var animalKingdom = new ThemePark(Guid.Parse("1c84a229-8862-4648-9c71-378ddd2c7693"), "Animal Kingdom", new Location(28.355302953495933, -81.59063737539063));

            // magicKingdom.AppendAttraction(teaCups);
            // magicKingdom.AppendAttraction(buzz);
            // magicKingdom.AppendAttraction(dwarfsMineTrains);
            // magicKingdom.AppendAttraction(tron);

            // var ioa = new ThemePark(Guid.Parse("267615cc-8943-4c2a-ae2c-5da728ca591f"), "Islands of Adventure", new Location(28.47225, -81.467594));
            var disneyWorld = new ResortArea("Walt Disney World", EasternTime);
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
