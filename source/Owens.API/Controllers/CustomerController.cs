// <copyright file="CustomerController.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Mvc;

namespace Owens.API.Controllers
{
    /// <inheritdoc />
    [ApiController]
    [Route("customer")]
    public class CustomerController : ControllerBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerController"/> class.
        /// </summary>
        public CustomerController()
        {
        }

        /// <summary>
        /// Returns a customer identifier.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [HttpGet("", Name = "customer-details")]
        public Task<IActionResult> Get()
        {
            var result = this.Ok(Guid.NewGuid());

            return Task.FromResult<IActionResult>(result);
        }
    }
}
