// <copyright file="BaseController.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Mvc;
using Owens.Application.Common.Contracts;

namespace Owens.API.Common
{
    /// <inheritdoc />
    public abstract class BaseController : ControllerBase
    {
        private readonly ILogger<BaseController> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseController"/> class.
        /// </summary>
        /// <param name="logger">An instance of the <see cref="ILogger{TCategoryName}"/> interface.</param>
        protected BaseController(ILogger<BaseController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Handles an Ok Object response.
        /// </summary>
        /// <typeparam name="TRequest">The type of the request.</typeparam>
        /// <typeparam name="TResponse">The type for the response.</typeparam>
        /// <param name="executionFunc">A <see cref="Func{TResult}"/> that returns the response type.</param>
        /// <param name="request">An instance of the request object.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        protected async Task<IActionResult> ExecuteOkObject<TRequest, TResponse>(Func<TRequest, CancellationToken, Task<TResponse>> executionFunc, TRequest request, CancellationToken cancellationToken)
        {
            return await ExecuteRequest(executionFunc, request, response => Ok(response), cancellationToken);
        }

        /// <summary>
        /// Handles a Created Object response.
        /// </summary>
        /// <typeparam name="TRequest">The type of the request.</typeparam>
        /// <typeparam name="TResponse">The type for the response.</typeparam>
        /// <param name="executionFunc">A <see cref="Func{TResult}"/> that returns the response type.</param>
        /// <param name="request">An instance of the request object.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        protected async Task<IActionResult> ExecuteCreated<TRequest, TResponse>(Func<TRequest, CancellationToken, Task<TResponse>> executionFunc, TRequest request, CancellationToken cancellationToken)
            where TResponse : EntityResponse
        {
            return await ExecuteRequest(executionFunc, request, response => Created(new Uri($"{response.Id}", UriKind.Relative), response), cancellationToken);
        }

        private async Task<IActionResult> ExecuteRequest<TRequest, TResponse>(Func<TRequest, CancellationToken, Task<TResponse>> executionFunc, TRequest request, Func<TResponse, IActionResult> resultFunc, CancellationToken cancellationToken)
        {
            try
            {
                var response = await executionFunc.Invoke(request, cancellationToken);

                return resultFunc.Invoke(response);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "A global exception occurred.");
            }

            return BadRequest();
        }
    }
}
