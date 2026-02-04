// <copyright file="AttractionController.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Mvc;
using NMediation.Abstractions;
using Owens.API.Common;
using Owens.Application.Attractions.Common;
using Owens.Domain.Attractions;

namespace Owens.API.Controllers.Attractions
{
    /// <inheritdoc />
    [ApiController]
    [Route("attraction")]
    public class AttractionController : BaseController
    {
        private readonly IAttractionRepository _attractionRepository;

        /// <inheritdoc />
        public AttractionController(IMediation mediation, IAttractionRepository attractionRepository)
            : base(mediation)
        {
            _attractionRepository = attractionRepository;
        }

        /// <summary>
        /// Adds an attraction.
        /// </summary>
        /// <param name="description">The attraction name.</param>
        /// <param name="externalId">THe external identifier.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [HttpPost("", Name = "AddAttraction")]
        public async Task<IActionResult> AddAttraction(string description, int externalId, CancellationToken cancellationToken = default)
        {
            await _attractionRepository.AddObject(new Attraction(description, externalId), cancellationToken);

            return Created();
        }
    }
}
