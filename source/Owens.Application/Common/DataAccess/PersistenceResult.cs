// <copyright file="PersistenceResult.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

namespace Owens.Application.Common.DataAccess
{
    /// <summary>
    /// Status for a persistence operation.
    /// </summary>
    public class PersistenceResult
    {
        private PersistenceResult(bool failed, int affectedCount)
        {
            Failed = failed;
            AffectedCount = affectedCount;
        }

        /// <summary>
        /// Gets a value indicating whether the operation failed.
        /// </summary>
        public bool Failed { get; }

        /// <summary>
        /// Gets the entity count changed.
        /// </summary>
        public int AffectedCount { get; }

        /// <summary>
        /// Returns a failed result.
        /// </summary>
        /// <returns>A <see cref="PersistenceResult"/> instance.</returns>
        public static PersistenceResult Failure()
        {
            return new PersistenceResult(true, 0);
        }

        /// <summary>
        /// Returns a success result.
        /// </summary>
        /// <param name="count">The count of entities affected.</param>
        /// <returns>A <see cref="PersistenceResult"/> instance.</returns>
        public static PersistenceResult Success(int count)
        {
            return new PersistenceResult(false, count);
        }
    }
}
