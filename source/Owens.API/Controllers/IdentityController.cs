// <copyright file="IdentityController.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using MediatR;
using Microsoft.AspNetCore.Mvc;
using Owens.Contracts.Members.Register;

namespace Owens.API.Controllers
{
    /// <inheritdoc />
    [ApiController]
    [Route("identity")]
    public class IdentityController : BaseController
    {
        /// <inheritdoc />
        public IdentityController(IMediator mediator)
            : base(mediator)
        {
        }

        /// <summary>
        /// Registers a new program member.
        /// </summary>
        /// <param name="request">An instance of the <see cref="RegisterMemberRequest"/> class.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        [HttpPost("", Name = "register-member")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> RegisterMember(RegisterMemberRequest request, CancellationToken cancellationToken)
        {
            return await ExecuteAction(request, response => Created(new Uri($"{response.Id}", UriKind.Relative), response), cancellationToken);
        }
    }
}
