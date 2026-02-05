// <copyright file="OperatorRepository.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using NMediation.Abstractions;
using Owens.Application.Operators.Common;
using Owens.Domain.Operators;
using Owens.Infrastructure.DataAccess.Common;

namespace Owens.Infrastructure.DataAccess.Operators
{
    /// <inheritdoc cref="IOperatorRepository" />
    public class OperatorRepository : BaseRepository<ResortOperator>, IOperatorRepository
    {
        /// <inheritdoc />
        public OperatorRepository(ApplicationContext applicationContext, IMediation mediation)
            : base(applicationContext, mediation)
        {
        }
    }
}
