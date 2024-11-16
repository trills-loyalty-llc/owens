// <copyright file="CustomerController.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using MediatR;
using Microsoft.AspNetCore.Mvc;
using Owens.Contracts.Customers;
using Owens.Contracts.Customers.Common;

namespace Owens.API.Controllers
{
    /// <inheritdoc />
    [ApiController]
    [Route("customer")]
    public class CustomerController : ControllerBase
    {
        private readonly ISender _sender;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerController"/> class.
        /// </summary>
        /// <param name="sender">An instance of the <see cref="ISender"/> interface.</param>
        public CustomerController(ISender sender)
        {
            _sender = sender;
        }

        /// <summary>
        /// Returns a customer identifier.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        [HttpGet("", Name = "customer-details")]
        [ProducesResponseType<CustomerResponse>(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            var result = await _sender.Send(new GetCustomerByIdRequest(), cancellationToken);

            return Ok(result);
        }
    }
}
