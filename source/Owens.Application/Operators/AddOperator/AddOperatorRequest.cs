// <copyright file="AddOperatorRequest.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;
using Owens.Application.Common.Mediation;

namespace Owens.Application.Operators.AddOperator
{
    /// <inheritdoc />
    public class AddOperatorRequest : IEnvelopePayload<AddOperatorResponse>
    {
        /// <summary>
        /// Gets the operator name.
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        public string Name { get; init; } = string.Empty;
    }
}
