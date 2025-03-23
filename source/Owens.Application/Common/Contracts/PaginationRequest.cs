// <copyright file="PaginationRequest.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;

namespace Owens.Application.Common.Contracts
{
    /// <inheritdoc />
    public abstract class PaginationRequest : IPagination
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PaginationRequest"/> class.
        /// </summary>
        /// <param name="skip">The number of entities to skip.</param>
        /// <param name="take">The number of entities to take.</param>
        protected PaginationRequest(int skip, int take)
        {
            Skip = skip;
            Take = take;
        }

        /// <summary>
        /// Gets how many entities to skip.
        /// </summary>
        [Range(0, 9999)]
        public int Skip { get; }

        /// <summary>
        /// Gets how many entities to take.
        /// </summary>
        [Range(10, 20)]
        public int Take { get; }
    }
}
