// <copyright file="OperationalStatus.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

namespace Owens.Domain.Attractions
{
    /// <summary>
    /// Current status of the attraction.
    /// </summary>
    public enum OperationalStatus
    {
        /// <summary>
        /// Attraction is operating normally.
        /// </summary>
        Operating = 0,

        /// <summary>
        /// Attraction is in a down state.
        /// </summary>
        Down = 1,

        /// <summary>
        /// Attraction is not scheduled for operation.
        /// </summary>
        Closed = 2,

        /// <summary>
        /// Attraction is under scheduled maintenance.
        /// </summary>
        Refurbishment = 3,
    }
}
