// <copyright file="ThemeParkFactory.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using FactoryFoundation;
using Owens.Application.ThemeParks.AddThemePark;
using Owens.Domain.Common;
using Owens.Domain.ThemeParks;

namespace Owens.Application.ThemeParks.Common
{
    /// <summary>
    /// Factory for theme parks.
    /// </summary>
    public class ThemeParkFactory :
        ICanTranslate<AddThemeParkRequest, ValidationEnvelope<ThemePark>>,
        ICanTranslate<ThemePark, AddThemeParkResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ThemeParkFactory"/> class.
        /// </summary>
        /// <param name="timeProvider">An instance of the <see cref="TimeProvider"/> class.</param>
        public ThemeParkFactory(TimeProvider timeProvider)
        {
        }

        /// <inheritdoc/>
        public ValidationEnvelope<ThemePark> TranslateTo(AddThemeParkRequest initial)
        {
            return FactoryHelpers.TryCreateValidate(() => new ThemePark(
                Guid.NewGuid(),
                initial.Description,
                initial.ExternalId,
                Location.FromMetadata(initial.Latitude, initial.Longitude)));
        }

        /// <inheritdoc/>
        public AddThemeParkResponse TranslateTo(ThemePark initial)
        {
            return new AddThemeParkResponse(initial.Id);
        }
    }
}
