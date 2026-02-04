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
        IGetAllObjects<ThemePark>
    {
    }
}
