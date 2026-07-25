// <copyright file="OperatorRepository.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using NMediation.Abstractions;
using Owens.Application.Operators.Common;
using Owens.Domain.Operators;
using Owens.Infrastructure.DataAccess.Common;

namespace Owens.Infrastructure.DataAccess.Operators
{
    /// <inheritdoc cref="IOperatorRepository" />
    public class OperatorRepository : BaseRepository<ResortOperator>, IOperatorRepository
    {
        private static readonly Func<IQueryable<ResortOperator>, IQueryable<ResortOperator>> IncludeFunc =
            operators => operators.Include(resortOperator => resortOperator.ResortAreas);

        /// <summary>
        /// Initializes a new instance of the <see cref="OperatorRepository"/> class.
        /// </summary>
        /// <param name="applicationContext">An instance of the <see cref="ApplicationContext"/> class.</param>
        /// <param name="mediation">An instance of the <see cref="IMediation"/> interface.</param>
        public OperatorRepository(ApplicationContext applicationContext, IMediation mediation)
            : base(applicationContext, mediation, IncludeFunc)
        {
        }
    }
}
