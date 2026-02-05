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
        /// <inheritdoc />
        public AttractionRepository(ApplicationContext applicationContext, IMediation mediation)
            : base(applicationContext, mediation)
        {
        }
    }
}
