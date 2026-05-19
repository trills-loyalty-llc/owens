// <copyright file="Ticketing.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using ClearDomain.Common;

namespace Owens.Domain.ThemeParks
{
    /// <summary>
    /// Denotes.
    /// </summary>
    public class Ticketing : ValueObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Ticketing"/> class.
        /// </summary>
        /// <param name="price">The price of the ticket.</param>
        /// <param name="ticketingType">The type of the ticket.</param>
        public Ticketing(decimal price, TicketingType ticketingType)
        {
            Price = price;
            TicketingType = ticketingType;
        }

        /// <summary>
        /// Gets the price of the ticket.
        /// </summary>
        public decimal Price { get; }

        /// <summary>
        /// Gets the type of the ticket.
        /// </summary>
        public TicketingType TicketingType { get; }

        /// <summary>
        /// Empty instance to satisfy nullable requirements.
        /// </summary>
        /// <returns>An empty <see cref="Ticketing"/> object.</returns>
        public static Ticketing Empty()
        {
            return new Ticketing(0m, TicketingType.Normal);
        }
    }
}
