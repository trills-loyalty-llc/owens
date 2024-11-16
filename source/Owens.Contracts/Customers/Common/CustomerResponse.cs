// <copyright file="CustomerResponse.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

namespace Owens.Contracts.Customers.Common
{
    /// <summary>
    /// Standard response class for a customer.
    /// </summary>
    public class CustomerResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerResponse"/> class.
        /// </summary>
        /// <param name="id">The response identifier.</param>
        public CustomerResponse(Guid id)
        {
            Id = id;
        }

        /// <summary>
        /// Gets the response identifier.
        /// </summary>
        public Guid Id { get; }
    }
}
