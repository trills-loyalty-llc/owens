// <copyright file="BaseController.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Owens.API.Controllers
{
    /// <inheritdoc />
    public abstract class BaseController : ControllerBase
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseController"/> class.
        /// </summary>
        /// <param name="mediator">An instance of the <see cref="IMediator"/> interface.</param>
        protected BaseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Wraps each request in a try-catch for global exception purposes.
        /// </summary>
        /// <typeparam name="TResponse">The response type.</typeparam>
        /// <param name="request">A <see cref="IRequest{T}"/> instance.</param>
        /// <param name="resultFunc">A <see cref="Func{TResult}"/> that will yield a <see cref="IActionResult"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        protected async Task<IActionResult> ExecuteAction<TResponse>(IRequest<TResponse> request, Func<TResponse, IActionResult> resultFunc, CancellationToken cancellationToken)
        {
            try
            {
                var response = await _mediator.Send(request, cancellationToken);

                return resultFunc.Invoke(response);
            }
            catch (Exception exception)
            {
                await _mediator.Publish(exception, cancellationToken);

                return BadRequest();
            }
        }
    }
}
