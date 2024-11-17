// <copyright file="MemberResponse.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

namespace Owens.Contracts.Member.Common
{
    /// <summary>
    /// Standard response class for a customer.
    /// </summary>
    public class MemberResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MemberResponse"/> class.
        /// </summary>
        /// <param name="id">The response identifier.</param>
        public MemberResponse(Guid id)
        {
            Id = id;
        }

        /// <summary>
        /// Gets the response identifier.
        /// </summary>
        public Guid Id { get; }
    }
}
