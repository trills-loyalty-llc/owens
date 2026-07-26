// <copyright file="SchedulePurchasesResult.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

namespace Owens.Infrastructure.ServiceClients.ThemeParks.Models.Scheduling
{
    /// <summary>
    /// A series of available purchases for the park on a specific date.
    /// </summary>
    public class SchedulePurchasesResult
    {
        /// <summary>
        /// Gets the identifier for a purchase. Combination of a name and identifier.
        /// </summary>
        public string Id { get; init; } = string.Empty;

        /// <summary>
        /// Gets the name of the purchase.
        /// </summary>
        public string Name { get; init; } = string.Empty;

        /// <summary>
        /// Gets or sets the type the purchase.
        /// </summary>
        public string Type { get; set; } = string.Empty;

        /// <summary>
        /// Gets a value indicating whether the purchase is available.
        /// </summary>
        public bool Available { get; init; }

        /// <summary>
        /// Gets the purchase price result.
        /// </summary>
        public PurchasePriceResult Price { get; init; } = PurchasePriceResult.Empty();
    }
}
