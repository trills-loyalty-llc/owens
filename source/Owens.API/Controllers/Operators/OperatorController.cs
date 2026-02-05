// <copyright file="OperatorController.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Mvc;
using NMediation.Abstractions;
using Owens.API.Common;
using Owens.Application.Operators.AddOperator;
using Owens.Application.Operators.ImportResortAreas;

namespace Owens.API.Controllers.Operators
{
    /// <inheritdoc />
    [ApiController]
    [Route("operator")]
    public class OperatorController : BaseController
    {
        /// <inheritdoc />
        public OperatorController(IMediation mediation)
            : base(mediation)
        {
        }

        /// <summary>
        /// Adds a resort and parks operator.
        /// </summary>
        /// <param name="request">An instance of the <see cref="AddOperatorRequest"/> class.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [HttpPost("", Name = "AddResortOperator")]
        [ProducesResponseType<AddOperatorResponse>(StatusCodes.Status201Created)]
        public async Task<IActionResult> AddResortOperator(AddOperatorRequest request, CancellationToken cancellationToken = default)
        {
            return await ExecuteCreated(request, cancellationToken);
        }

        /// <summary>
        /// Imports all basic resort area information.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [HttpPost("resort-areas", Name = "ImportResortAreas")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> ImportResortAreas(CancellationToken cancellationToken = default)
        {
            return await ExecuteNoContent(new ImportResortAreasRequest(), cancellationToken);
        }
    }
}
