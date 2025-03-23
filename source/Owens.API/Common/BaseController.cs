// <copyright file="BaseController.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using MediatorBuddy;
using MediatorBuddy.AspNet;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Owens.Application.Common.Contracts;

namespace Owens.API.Common
{
    /// <inheritdoc />
    public abstract class BaseController : MediatorBuddyApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseController"/> class.
        /// </summary>
        /// <param name="mediator">An instance of a <see cref="IMediator"/> interface.</param>
        protected BaseController(IMediator mediator)
            : base(mediator)
        {
        }

        /// <summary>
        /// Handles a Created Object response.
        /// </summary>
        /// <typeparam name="TResponse">The type fo the response.</typeparam>
        /// <param name="request">A <see cref="IEnvelopeRequest{TResponse}"/> object.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        protected async Task<IActionResult> ExecuteCreatedLocation<TResponse>(IEnvelopeRequest<TResponse> request, CancellationToken cancellationToken)
            where TResponse : EntityResponse
        {
            return await ExecuteCreated(request, response => new Uri($"{response.Id}", UriKind.Relative), cancellationToken);
        }
    }
}
