// <copyright file="IOperatorRepository.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using Owens.Application.Common.DataAccess;
using Owens.Domain.Operators;

namespace Owens.Application.Operators.Common
{
    /// <summary>
    /// Interface for interacting with operator persistence.
    /// </summary>
    public interface IOperatorRepository :
        IAddObject<ResortOperator>,
        IGetAllObjects<ResortOperator>
    {
    }
}
