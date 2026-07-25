// <copyright file="AttractionRepository.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using NMediation.Abstractions;
using Owens.Application.Attractions.Common;
using Owens.Domain.Attractions;
using Owens.Infrastructure.DataAccess.Common;

namespace Owens.Infrastructure.DataAccess.Attractions
{
    /// <inheritdoc cref="IAttractionRepository" />
    public class AttractionRepository : BaseRepository<Attraction>, IAttractionRepository
    {
        private static readonly Func<IQueryable<Attraction>, IQueryable<Attraction>> IncludeFunc = attractions => attractions;

        /// <summary>
        /// Initializes a new instance of the <see cref="AttractionRepository"/> class.
        /// </summary>
        /// <param name="applicationContext">An instance of the <see cref="ApplicationContext"/> class.</param>
        /// <param name="mediation">An instance of the <see cref="IMediation"/> interface.</param>
        public AttractionRepository(ApplicationContext applicationContext, IMediation mediation)
            : base(applicationContext, mediation, IncludeFunc)
        {
        }
    }
}
