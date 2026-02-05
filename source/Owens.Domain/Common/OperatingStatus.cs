// <copyright file="OperatingStatus.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

namespace Owens.Domain.Common
{
    /// <summary>
    /// The operating status of a park.
    /// </summary>
    public enum OperatingStatus
    {
        /// <summary>
        /// The park or attraction is closed.
        /// </summary>
        Closed = 0,

        /// <summary>
        /// The park or attraction is down or not working.
        /// </summary>
        Down = 1,

        /// <summary>
        /// The park or attraction is operating.
        /// </summary>
        Operating = 3,

        /// <summary>
        /// The park or attraction is under refurbishment.
        /// </summary>
        Refurbishment = 4,
    }
}
