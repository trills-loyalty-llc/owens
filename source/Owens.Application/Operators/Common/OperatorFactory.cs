// <copyright file="OperatorFactory.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using FactoryFoundation;
using Owens.Application.Operators.AddOperator;
using Owens.Domain.Operators;

namespace Owens.Application.Operators.Common
{
    /// <summary>
    /// Operator factory.
    /// </summary>
    public class OperatorFactory :
        ICanTranslate<AddOperatorRequest, ResortOperator>,
        ICanTranslate<ResortOperator, AddOperatorResponse>
    {
        /// <inheritdoc/>
        public ResortOperator TranslateTo(AddOperatorRequest initial)
        {
            return new ResortOperator(initial.Name);
        }

        /// <inheritdoc/>
        public AddOperatorResponse TranslateTo(ResortOperator initial)
        {
            return new AddOperatorResponse(initial.Id);
        }
    }
}
