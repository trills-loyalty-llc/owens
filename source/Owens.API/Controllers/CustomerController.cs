// <copyright file="CustomerController.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Mvc;

namespace Owens.API.Controllers
{
    [ApiController]
    [Route("customer")]
    public class CustomerController : ControllerBase
    {
        public CustomerController()
        {
        }

        [HttpGet("", Name = "customer-details")]
        public Task<IActionResult> Get()
        {
            var result = this.Ok(Guid.NewGuid());

            return Task.FromResult<IActionResult>(result);
        }
    }
}
