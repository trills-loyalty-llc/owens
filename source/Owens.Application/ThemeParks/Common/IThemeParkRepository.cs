// <copyright file="IThemeParkRepository.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using Owens.Application.Common.DataAccess;
using Owens.Domain.ThemeParks;

namespace Owens.Application.ThemeParks.Common
{
    /// <summary>
    /// Interface for interacting with <see cref="ThemePark"/> persistence.
    /// </summary>
    public interface IThemeParkRepository :
        IAddObject<ThemePark>,
        IUpdateObject<ThemePark>,
        IGetAllObjects<ThemePark>,
        IGetObjectById<ThemePark>
    {
        /// <summary>
        /// Checks to see if a schedule already exists for a given theme park and date.
        /// </summary>
        /// <param name="id">The identifier of a theme park.</param>
        /// <param name="date">A Date to check for a schedule against.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<bool> ScheduleExists(Guid id, DateOnly date);
    }
}
