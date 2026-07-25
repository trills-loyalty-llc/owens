// <copyright file="OperatorResponse.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using Owens.Application.Common.Contracts;
using System.ComponentModel.DataAnnotations;

namespace Owens.Application.Operators.Common
{
    /// <inheritdoc />
    public class OperatorResponse : EntityResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OperatorResponse"/> class.
        /// </summary>
        /// <param name="id">The identifier of the resort operator.</param>
        /// <param name="name">The legal name of the operator.</param>
        /// <param name="resortCount">A count of the logical number of resort areas.</param>
        public OperatorResponse(Guid id, string name, int resortCount)
            : base(id)
        {
            Name = name;
            ResortCount = resortCount;
        }

        /// <summary>
        /// Gets the name of the resort operator.
        /// </summary>
        [Required]
        public string Name { get; }

        /// <summary>
        /// Gets the total number of resorts the operator manages.
        /// </summary>
        [Required]
        public int ResortCount { get; }
    }
}
