// <copyright file="BaseController.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Mvc;
using NMediation.Abstractions;
using Owens.Application.Common.Contracts;
using Owens.Application.Common.Mediation;
using Owens.Infrastructure.ErrorHandling;

namespace Owens.API.Common
{
    /// <inheritdoc />
    public abstract class BaseController : ControllerBase
    {
        private readonly IMediation _mediation;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseController"/> class.
        /// </summary>
        /// <param name="mediation">An instance of the <see cref="IMediation"/> interface.</param>
        protected BaseController(IMediation mediation)
        {
            _mediation = mediation;
        }

        /// <summary>
        /// Handles an Ok Object response.
        /// </summary>
        /// <typeparam name="TResponse">The type for the response.</typeparam>
        /// <param name="request">An instance of the request object.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        protected async Task<IActionResult> ExecuteOkObject<TResponse>(IPayload<Envelope<TResponse>> request, CancellationToken cancellationToken)
        {
            return await ExecuteRequest(request, response => Ok(response), cancellationToken);
        }

        /// <summary>
        /// Handles a Created Object response.
        /// </summary>
        /// <typeparam name="TResponse">The type for the response.</typeparam>
        /// <param name="request">An instance of the request object.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        protected async Task<IActionResult> ExecuteCreated<TResponse>(IPayload<Envelope<TResponse>> request, CancellationToken cancellationToken)
            where TResponse : EntityResponse
        {
            return await ExecuteRequest(request, response => Created(new Uri($"{response.Id}", UriKind.Relative), response), cancellationToken);
        }

        /// <summary>
        /// Handles a No Content response.
        /// </summary>
        /// <typeparam name="TResponse">The type for the response.</typeparam>
        /// <param name="request">An instance of the request object.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        protected async Task<IActionResult> ExecuteNoContent<TResponse>(IPayload<Envelope<TResponse>> request, CancellationToken cancellationToken)
        {
            return await ExecuteRequest(request, response => NoContent(), cancellationToken);
        }

        private async Task<IActionResult> ExecuteRequest<TResponse>(IPayload<Envelope<TResponse>> payload, Func<TResponse, IActionResult> resultFunc, CancellationToken cancellationToken)
        {
            try
            {
                var envelope = await _mediation.Mediate(payload, cancellationToken);

                if (envelope.Status == ApplicationStatus.Success)
                {
                    return resultFunc.Invoke(envelope.Response);
                }
            }
            catch (Exception exception)
            {
                var occurrence = GeneralExceptionOccurred.FromException(exception);

                await _mediation.Publish(occurrence, cancellationToken);
            }

            return BadRequest();
        }
    }
}
