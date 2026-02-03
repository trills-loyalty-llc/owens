// <copyright file="IDescription.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

namespace Owens.Domain.Common
{
    /// <summary>
    /// Denotes an entity with an alphaNumeric description.
    /// </summary>
    public interface IDescription
    {
        /// <summary>
        /// Gets an alphaNumeric description.
        /// </summary>
        public string Description { get; }
    }
}
