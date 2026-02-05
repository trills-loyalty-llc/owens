// <copyright file="OperatorFactory.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using FactoryFoundation;
using Owens.Application.Operators.AddOperator;
using Owens.Application.Services.ThemeParks.Models;
using Owens.Domain.Operators;

namespace Owens.Application.Operators.Common
{
    /// <summary>
    /// Operator factory.
    /// </summary>
    public class OperatorFactory :
        ICanTranslate<AddOperatorRequest, ValidationEnvelope<ResortOperator>>,
        ICanTranslate<ResortOperator, AddOperatorResponse>,
        ICanTranslate<Destination, ResortArea>
    {
        /// <inheritdoc/>
        public ValidationEnvelope<ResortOperator> TranslateTo(AddOperatorRequest initial)
        {
            return FactoryHelpers.TryCreateValidate(() => new ResortOperator(initial.Name));
        }

        /// <inheritdoc/>
        public AddOperatorResponse TranslateTo(ResortOperator initial)
        {
            return new AddOperatorResponse(initial.Id);
        }

        /// <inheritdoc/>
        public ResortArea TranslateTo(Destination initial)
        {
            return new ResortArea(initial.Id, initial.Description);
        }
    }
}
