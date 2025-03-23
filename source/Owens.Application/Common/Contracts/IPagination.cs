// <copyright file="IPagination.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

namespace Owens.Application.Common.Contracts
{
    /// <summary>
    /// Base interface for pagination.
    /// </summary>
    public interface IPagination
    {
        /// <summary>
        /// Gets the skip count.
        /// </summary>
        public int Skip { get; }

        /// <summary>
        /// Gets the take count.
        /// </summary>
        public int Take { get; }
    }
}
