// <copyright file="GetMemberByIdHandlerTests.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using Owens.Application.Members.GetById;
using Owens.Contracts.Members.GetById;

namespace Owens.Tests.Application.Members
{
    /// <summary>
    /// Tests for the <see cref="GetMemberByIdHandler"/> class.
    /// </summary>
    [TestClass]
    public class GetMemberByIdHandlerTests
    {
        private readonly GetMemberByIdHandler _handler;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetMemberByIdHandlerTests"/> class.
        /// </summary>
        public GetMemberByIdHandlerTests()
        {
            _handler = new GetMemberByIdHandler();
        }

        /// <summary>
        /// Handle, success, is correct.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [TestMethod]
        public async Task Handle_Success_IsCorrect()
        {
            var result = await _handler.Handle(new GetMemberByIdRequest(), CancellationToken.None);

            Assert.IsNotNull(result.Response);
        }
    }
}
