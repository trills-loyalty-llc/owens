// <copyright file="ResortArea.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using ClearDomain.GuidPrimary;
using Owens.Domain.ThemeParks;

namespace Owens.Domain.Operators
{
    /// <summary>
    /// Designates a boundary around a series of theme parks that may or may not be geographically isolated.
    /// </summary>
    public class ResortArea : Entity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResortArea"/> class.
        /// </summary>
        /// <param name="description">A description of the resort area.</param>
        /// <param name="timeZoneId">A time zone identifier for the resort.</param>
        public ResortArea(string description, string timeZoneId)
        {
            Description = description;
            TimeZoneId = timeZoneId;
            ThemeParks = new List<ThemePark>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResortArea"/> class.
        /// </summary>
        /// <param name="id">The resort area identifier.</param>
        /// <param name="description">A description of the resort area.</param>
        /// <param name="timeZoneId">A time zone identifier for the resort.</param>
        public ResortArea(Guid id, string description, string timeZoneId)
            : base(id)
        {
            Description = description;
            TimeZoneId = timeZoneId;
            ThemeParks = new List<ThemePark>();
        }

        /// <summary>
        /// Gets the description of the resort area.
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Gets the time zone identifier.
        /// </summary>
        public string TimeZoneId { get; }

        /// <summary>
        /// Gets all theme parks for a resort.
        /// </summary>
        public ICollection<ThemePark> ThemeParks { get; }

        /// <summary>
        /// Appends a theme park to a resort.
        /// </summary>
        /// <param name="themePark">A <see cref="ThemePark"/> instance.</param>
        public void AppendThemePark(ThemePark themePark)
        {
            ThemeParks.Add(themePark);
        }
    }
}
