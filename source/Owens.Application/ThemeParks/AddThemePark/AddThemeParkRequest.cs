// <copyright file="AddThemeParkRequest.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using Owens.Application.Common.Mediation;
using System.ComponentModel.DataAnnotations;

namespace Owens.Application.ThemeParks.AddThemePark
{
    /// <inheritdoc />
    public class AddThemeParkRequest : IEnvelopePayload<AddThemeParkResponse>
    {
        /// <summary>
        /// Gets the theme park description.
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        public string Description { get; init; } = string.Empty;

        /// <summary>
        /// Gets the latitude.
        /// </summary>
        [Range(-90, 90)]
        public double Latitude { get; init; }

        /// <summary>
        /// Gets the longitude.
        /// </summary>
        [Range(-180, 180)]
        public double Longitude { get; init; }

        /// <summary>
        /// Gets the external scheduling identifier.
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        public Guid ExternalSchedulingId { get; init; }
    }
}
