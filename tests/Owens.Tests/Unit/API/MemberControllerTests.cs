// <copyright file="MemberControllerTests.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Owens.API.Controllers;
using Owens.Contracts.Member;
using Owens.Contracts.Member.Common;

namespace Owens.Tests.Unit.API
{
    /// <summary>
    /// Tests for the <see cref="MemberController"/> class.
    /// </summary>
    [TestClass]
    public class MemberControllerTests
    {
        /// <summary>
        /// Member details has correct response type.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task Get_HasCorrectResponseType()
        {
            var sender = new Mock<ISender>();
            sender.Setup(x => x.Send(It.IsAny<GetMemberByIdRequest>(), CancellationToken.None))
                .ReturnsAsync(new MemberResponse(Guid.NewGuid()));

            var controller = new MemberController(sender.Object);

            var result = await controller.GetMemberById(CancellationToken.None);

            Assert.IsInstanceOfType<OkObjectResult>(result);
        }
    }
}
