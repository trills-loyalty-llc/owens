// <copyright file="ThemeParkRepository.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using NMediation.Abstractions;
using Owens.Application.ThemeParks.Common;
using Owens.Domain.ThemeParks;
using Owens.Infrastructure.DataAccess.Common;

namespace Owens.Infrastructure.DataAccess.ThemeParks
{
    /// <inheritdoc cref="IThemeParkRepository" />
    public class ThemeParkRepository : BaseRepository<ThemePark>, IThemeParkRepository
    {
        /// <inheritdoc />
        public ThemeParkRepository(ApplicationContext applicationContext, IMediation mediation)
            : base(applicationContext, mediation)
        {
        }
    }
}
