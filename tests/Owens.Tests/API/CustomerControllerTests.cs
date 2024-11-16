// <copyright file="CustomerControllerTests.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Mvc;
using Owens.API.Controllers;

namespace Owens.Tests.API
{
    /// <summary>
    /// Tests for the <see cref="CustomerController"/> class.
    /// </summary>
    [TestClass]
    public sealed class CustomerControllerTests
    {
        /// <summary>
        /// Customer details has correct response type.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task Get_HasCorrectResponseType()
        {
            var controller = new CustomerController();

            var result = await controller.Get();

            Assert.IsInstanceOfType<OkObjectResult>(result);
        }
    }
}
