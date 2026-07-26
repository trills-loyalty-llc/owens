// <copyright file="PurchasePriceResult.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

namespace Owens.Infrastructure.ServiceClients.ThemeParks.Models.Scheduling
{
    /// <summary>
    /// The pricing for a scheduled purchase.
    /// </summary>
    public class PurchasePriceResult
    {
        /// <summary>
        /// Gets the amount for a purchase. Format is in total number of pennies.
        /// </summary>
        public double Amount { get; init; }

        /// <summary>
        /// Returns an empty result to satisfy nullable requirements.
        /// </summary>
        /// <returns>A <see cref="PurchasePriceResult"/> instance.</returns>
        public static PurchasePriceResult Empty()
        {
            return new PurchasePriceResult();
        }
    }
}
