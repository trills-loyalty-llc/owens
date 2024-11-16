// <copyright file="CustomerControllerTests.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Owens.API.Controllers;
using Owens.Contracts.Customers;
using Owens.Contracts.Customers.Common;

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
            var sender = new Mock<ISender>();
            sender.Setup(x => x.Send(It.IsAny<GetCustomerByIdRequest>(), CancellationToken.None))
                .ReturnsAsync(new CustomerResponse(Guid.NewGuid()));

            var controller = new CustomerController(sender.Object);

            var result = await controller.Get(CancellationToken.None);

            Assert.IsInstanceOfType<OkObjectResult>(result);
        }
    }
}
