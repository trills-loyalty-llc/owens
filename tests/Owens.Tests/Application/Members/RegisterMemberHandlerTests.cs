// <copyright file="RegisterMemberHandlerTests.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using ChainStrategy;
using Moq;
using Owens.Application.Members.Register;
using Owens.Application.Members.Register.RegistrationChain;
using Owens.Contracts.Members.Register;

namespace Owens.Tests.Application.Members
{
    /// <summary>
    /// Tests for the <see cref="RegisterMemberHandler"/> class.
    /// </summary>
    [TestClass]
    public class RegisterMemberHandlerTests
    {
        private readonly Mock<IChainFactory> _chainFactory;
        private readonly RegisterMemberHandler _handler;

        /// <summary>
        /// Initializes a new instance of the <see cref="RegisterMemberHandlerTests"/> class.
        /// </summary>
        public RegisterMemberHandlerTests()
        {
            _chainFactory = new Mock<IChainFactory>();
            _handler = new RegisterMemberHandler(_chainFactory.Object);
        }

        /// <summary>
        /// Handle, failure, is correct.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task Handle_Failure_IsCorrect()
        {
            var payload = RegisterMemberPayload.FromRequest(new RegisterMemberRequest());
            payload.Faulted();

            _chainFactory.Setup(x => x.Execute(It.IsAny<RegisterMemberPayload>(), CancellationToken.None))
                .ReturnsAsync(payload);

            var result = await _handler.Handle(new RegisterMemberRequest(), CancellationToken.None);

            Assert.IsNull(result.Response);
        }

        /// <summary>
        /// Handle, success, is correct.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task Handle_Success_IsCorrect()
        {
            var payload = RegisterMemberPayload.FromRequest(new RegisterMemberRequest());

            _chainFactory.Setup(x => x.Execute(It.IsAny<RegisterMemberPayload>(), CancellationToken.None))
                .ReturnsAsync(payload);

            var result = await _handler.Handle(new RegisterMemberRequest(), CancellationToken.None);

            Assert.IsNotNull(result.Response);
        }
    }
}
