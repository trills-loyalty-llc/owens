// <copyright file="AttractionType.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

namespace Owens.Domain.Attractions
{
    /// <summary>
    /// Designates the type of the attraction.
    /// </summary>
    public enum AttractionType
    {
        /// <summary>
        /// A physical meeting of a character.
        /// </summary>
        CharacterMeet,

        /// <summary>
        /// Hybrid between gentle ride and trill, but typically indoors.
        /// </summary>
        Dark,

        /// <summary>
        /// A defined show where guests may or may not be standing.
        /// </summary>
        Entertainment,

        /// <summary>
        /// Outdoor attraction that is geared towards children.
        /// </summary>
        Gentle,

        /// <summary>
        /// A tracked ride that has a minimum speed rating.
        /// </summary>
        RollerCoaster,

        /// <summary>
        /// Low demand attraction that moves guests from one point to another.
        /// </summary>
        Transportation,

        /// <summary>
        /// An outdoor attraction that is characterized by higher intensity.
        /// </summary>
        Trill,

        /// <summary>
        /// An attraction where most of the ride vehicle is floating for the duration of the ride.
        /// </summary>
        Water,

        /// <summary>
        /// The attraction type is pending and needs to be updated.
        /// </summary>
        Pending,
    }
}
