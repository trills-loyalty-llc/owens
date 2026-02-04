// <copyright file="ThemeParkController.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Mvc;
using NMediation.Abstractions;
using Owens.API.Common;
using Owens.Application.ThemeParks.AddThemePark;

namespace Owens.API.Controllers.ThemeParks
{
    /// <inheritdoc />
    [ApiController]
    [Route("theme-park")]
    public class ThemeParkController : BaseController
    {
        /// <inheritdoc />
        public ThemeParkController(IMediation mediation)
            : base(mediation)
        {
        }

        /// <summary>
        /// Adds a theme park.
        /// </summary>
        /// <param name="request">An <see cref="AddThemeParkRequest"/> object.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [HttpPost("", Name = "AddThemePark")]
        [ProducesResponseType<AddThemeParkResponse>(StatusCodes.Status201Created)]
        public async Task<IActionResult> AddThemePark(AddThemeParkRequest request, CancellationToken cancellationToken = default)
        {
            return await ExecuteCreated(request, cancellationToken);
        }
    }
}
