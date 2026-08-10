// <copyright file="ThemeParkRepository.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using NMediation.Abstractions;
using Owens.Application.ThemeParks.Common;
using Owens.Domain.ThemeParks;
using Owens.Infrastructure.DataAccess.Common;

namespace Owens.Infrastructure.DataAccess.ThemeParks
{
    /// <inheritdoc cref="IThemeParkRepository" />
    public class ThemeParkRepository : BaseRepository<ThemePark>, IThemeParkRepository
    {
        private static readonly Func<IQueryable<ThemePark>, IQueryable<ThemePark>> IncludeFunc =
            themeParks => themeParks.Include(themePark => themePark.Attractions);

        /// <summary>
        /// Initializes a new instance of the <see cref="ThemeParkRepository"/> class.
        /// </summary>
        /// <param name="applicationContext">An instance of the <see cref="ApplicationContext"/> class.</param>
        /// <param name="mediation">An instance of the <see cref="IMediation"/> interface.</param>
        public ThemeParkRepository(ApplicationContext applicationContext, IMediation mediation)
            : base(applicationContext, mediation, IncludeFunc)
        {
        }

        /// <inheritdoc/>
        public async Task<bool> ScheduleExists(Guid id, DateOnly date)
        {
            return await Context.ThemeParks
                .Where(themePark => themePark.Id == id)
                .AnyAsync(themePark => themePark.Admissions
                    .Any(admission =>
                        admission.Opening.Month == date.Month &&
                        admission.Opening.Year == date.Year &&
                        admission.Opening.Day == date.Day));
        }
    }
}
