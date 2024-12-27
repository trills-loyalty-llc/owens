// <copyright file="MemberController.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using MediatorBuddy.AspNet;
using MediatorBuddy.AspNet.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Owens.Contracts.Members.Register;

namespace Owens.API.Controllers
{
    /// <inheritdoc />
    [ApiController]
    [Route("member")]
    public class MemberController : MediatorBuddyApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MemberController"/> class.
        /// </summary>
        /// <param name="mediator">An instance of the <see cref="IMediator"/> interface.</param>
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
            return await ExecuteRequest(
                request,
                ResponseOptions.CreatedResponse<RegisterMemberResponse>(response => new Uri($"{response.Id}", UriKind.Relative)),
                cancellationToken);
        }
    }
}
