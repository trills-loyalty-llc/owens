// <copyright file="MemberController.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using MediatR;
using Microsoft.AspNetCore.Mvc;
using Owens.Contracts.Member;
using Owens.Contracts.Member.Common;

namespace Owens.API.Controllers
{
    /// <inheritdoc />
    [ApiController]
    [Route("member")]
    public class MemberController : ControllerBase
    {
        private readonly ISender _sender;

        /// <summary>
        /// Initializes a new instance of the <see cref="MemberController"/> class.
        /// </summary>
        /// <param name="sender">An instance of the <see cref="ISender"/> interface.</param>
        public MemberController(ISender sender)
        {
            _sender = sender;
        }

        /// <summary>
        /// Returns a customer identifier.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        [HttpGet("", Name = "customer-details")]
        [ProducesResponseType<MemberResponse>(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetMemberById(CancellationToken cancellationToken)
        {
            var result = await _sender.Send(new GetMemberByIdRequest(), cancellationToken);

            return Ok(result);
        }
    }
}
