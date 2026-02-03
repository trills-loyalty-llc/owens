// <copyright file="ResortOperator.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using ClearDomain.GuidPrimary;

namespace Owens.Domain.Operators
{
    /// <summary>
    /// The owner and operator of resorts, hotels, and restaurants.
    /// </summary>
    public class ResortOperator : AggregateRoot
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResortOperator"/> class.
        /// </summary>
        public ResortOperator()
        {
            ResortAreas = new List<ResortArea>();
        }

        /// <summary>
        /// Gets all resorts for an operator.
        /// </summary>
        public ICollection<ResortArea> ResortAreas { get; }
    }
}
