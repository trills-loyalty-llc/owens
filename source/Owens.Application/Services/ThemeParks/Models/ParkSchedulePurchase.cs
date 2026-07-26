// <copyright file="ParkSchedulePurchase.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

namespace Owens.Application.Services.ThemeParks.Models
{
    /// <summary>
    /// An applicable purchase for a park schedule.
    /// </summary>
    public class ParkSchedulePurchase
    {
        /// <summary>
        /// Gets the id for the purchase. This is a combination of a description and external id.
        /// </summary>
        public string Id { get; init; } = string.Empty;

        /// <summary>
        /// Gets the name of the purchase.
        /// </summary>
        public string Name { get; init; } = string.Empty;

        /// <summary>
        /// Gets the type of the purchase as either a package or single attraction.
        /// </summary>
        public string Type { get; init; } = string.Empty;

        /// <summary>
        /// Gets the price of the purchase in number of pennies.
        /// </summary>
        public double Price { get; init; }

        /// <summary>
        /// Gets a value indicating whether the purchase is available.
        /// </summary>
        public bool Available { get; init; }
    }
}
