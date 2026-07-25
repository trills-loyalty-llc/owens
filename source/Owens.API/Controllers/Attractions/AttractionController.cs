// <copyright file="AttractionController.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Mvc;
using NMediation.Abstractions;
using Owens.API.Common;
using Owens.Application.Attractions.AddAttraction;
using Owens.Application.Attractions.ImportAttractions;

namespace Owens.API.Controllers.Attractions
{
    /// <inheritdoc />
    [ApiController]
    [Route("attraction")]
    public class AttractionController : BaseController
    {
        /// <inheritdoc />
        public AttractionController(IMediation mediation)
            : base(mediation)
        {
        }

        /// <summary>
        /// Adds an attraction.
        /// </summary>
        /// <param name="request">An <see cref="AddAttractionRequest"/> instance.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [HttpPost("", Name = "AddAttraction")]
        [ProducesResponseType<AddAttractionResponse>(StatusCodes.Status201Created)]
        public async Task<IActionResult> AddAttraction(AddAttractionRequest request, CancellationToken cancellationToken = default)
        {
            return await ExecuteCreated(request, cancellationToken);
        }

        /// <summary>
        /// Imports all attractions for a theme park.
        /// </summary>
        /// <param name="id">The identifier for a theme park.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [HttpPost("{id:guid}", Name = "ImportAttractions")]
        [ProducesResponseType<ImportAttractionsResponse>(StatusCodes.Status201Created)]
        public async Task<IActionResult> ImportAttractions(Guid id, CancellationToken cancellationToken = default)
        {
            return await ExecuteCreated(new ImportAttractionsRequest(id), cancellationToken);
        }
    }
}
