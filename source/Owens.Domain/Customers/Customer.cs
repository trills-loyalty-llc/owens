// <copyright file="Customer.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

namespace Owens.Domain.Customers
{
    /// <summary>
    /// A customer represents an individual person who interacts with the loyalty platform.
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// Gets the identifier.
        /// </summary>
        public Guid Id { get; } = Guid.NewGuid();
    }
}
