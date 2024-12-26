// <copyright file="MemberController.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Owens.Contracts.Members.Register;

namespace Owens.API.Controllers
{
    /// <inheritdoc />
    [ApiController]
    [Route("member")]
    public class MemberController : BaseController
    {
        /// <inheritdoc />
        public MemberController(IMediator mediator)
            : base(mediator)
        {
        }

        /// <summary>
        /// Registers a new program member.
        /// </summary>
        /// <param name="request">An instance of the <see cref="RegisterMemberRequest"/> class.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        [AllowAnonymous]
        [HttpPost("", Name = "register")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> RegisterMember(RegisterMemberRequest request, CancellationToken cancellationToken)
        {
            return await ExecuteAction(request, response => Created(new Uri($"{response.Id}", UriKind.Relative), response), cancellationToken);
        }
    }
}
