// <copyright file="ResortOperator.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using ClearDomain.GuidPrimary;
using Owens.Domain.Common;

namespace Owens.Domain.Operators
{
    /// <summary>
    /// The owner and operator of resorts, hotels, and restaurants.
    /// </summary>
    public class ResortOperator : AggregateRoot, IDescription
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResortOperator"/> class.
        /// </summary>
        /// <param name="description">The name of the operator.</param>
        public ResortOperator(string description)
        {
            Description = description;
            ResortAreas = new List<ResortArea>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResortOperator"/> class.
        /// </summary>
        /// <param name="id">The identifier of the operator.</param>
        /// <param name="description">The name of the operator.</param>
        public ResortOperator(Guid id, string description)
            : base(id)
        {
            Description = description;
            ResortAreas = new List<ResortArea>();
        }

        /// <inheritdoc/>
        public string Description { get; }

        /// <summary>
        /// Gets all resorts for an operator.
        /// </summary>
        public ICollection<ResortArea> ResortAreas { get; }

        /// <summary>
        /// Appends a resort area.
        /// </summary>
        /// <param name="resortArea">A <see cref="ResortArea"/> instance.</param>
        public void AppendResortArea(ResortArea resortArea)
        {
            ResortAreas.Add(resortArea);
        }
    }
}
