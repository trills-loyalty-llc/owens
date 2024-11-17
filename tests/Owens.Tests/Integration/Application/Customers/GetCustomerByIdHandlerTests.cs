// <copyright file="GetCustomerByIdHandlerTests.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Owens.Application.Customers.GetById;
using Owens.Contracts.Customers;

namespace Owens.Tests.Integration.Application.Customers
{
    /// <summary>
    /// Tests for the <see cref="GetCustomerByIdHandler"/> class.
    /// </summary>
    [TestClass]
    public class GetCustomerByIdHandlerTests
    {
        /// <summary>
        /// Successful path has the correct response.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task Handle_Success_HasCorrectResponseAsync()
        {
            var handler = new GetCustomerByIdHandler();

            var result = await handler.Handle(new GetCustomerByIdRequest(), CancellationToken.None);

            Assert.IsNotNull(result);
        }
    }
}
