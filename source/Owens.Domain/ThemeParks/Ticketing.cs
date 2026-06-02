// <copyright file="Ticketing.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using ClearDomain.GuidPrimary;

namespace Owens.Domain.ThemeParks
{
    /// <summary>
    /// Denotes.
    /// </summary>
    public class Ticketing : Entity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Ticketing"/> class.
        /// </summary>
        /// <param name="description">A description of the ticket.</param>
        /// <param name="price">The price of the ticket.</param>
        /// <param name="ticketingType">The type of the ticket.</param>
        public Ticketing(string description, decimal price, TicketingType ticketingType)
        {
            Description = description;
            Price = price;
            TicketingType = ticketingType;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Ticketing"/> class.
        /// </summary>
        /// <param name="id">The identifier for the ticket.</param>
        /// <param name="description">A description of the ticket.</param>
        /// <param name="price">The price of the ticket.</param>
        /// <param name="ticketingType">The type of the ticket.</param>
        public Ticketing(Guid id, string description, decimal price, TicketingType ticketingType)
            : base(id)
        {
            Description = description;
            Price = price;
            TicketingType = ticketingType;
        }

        /// <summary>
        /// Gets the ticketing description.
        /// </summary>
        public string Description { get; }

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
            return new Ticketing(string.Empty, 0, TicketingType.Normal);
        }
    }
}
