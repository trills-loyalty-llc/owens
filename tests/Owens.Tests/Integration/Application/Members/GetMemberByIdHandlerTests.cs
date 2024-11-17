// <copyright file="GetMemberByIdHandlerTests.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Owens.Application.Members.GetById;
using Owens.Contracts.Member;

namespace Owens.Tests.Integration.Application.Customers
{
    /// <summary>
    /// Tests for the <see cref="GetMemberByIdHandler"/> class.
    /// </summary>
    [TestClass]
    public class GetMemberByIdHandlerTests
    {
        /// <summary>
        /// Successful path has the correct response.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task Handle_Success_HasCorrectResponseAsync()
        {
            var handler = new GetMemberByIdHandler();

            var result = await handler.Handle(new GetMemberByIdRequest(), CancellationToken.None);

            Assert.IsNotNull(result);
        }
    }
}
