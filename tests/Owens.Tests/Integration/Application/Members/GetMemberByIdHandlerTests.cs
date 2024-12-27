// <copyright file="GetMemberByIdHandlerTests.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using Owens.Contracts.Members.GetById;
using Owens.Tests.Integration.Common;

namespace Owens.Tests.Integration.Application.Members
{
    /// <inheritdoc />
    [TestClass]
    public class GetMemberByIdHandlerTests : BaseIntegrationTest
    {
        /// <summary>
        /// Handle, success, is correct.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task Handle_Success_IsCorrectAsync()
        {
            var handler = IntegrationHelpers.GetHandler<GetMemberByIdRequest, GetMemberByIdResponse>();

            var result = await handler.Handle(new GetMemberByIdRequest(), CancellationToken.None);
        }
    }
}
