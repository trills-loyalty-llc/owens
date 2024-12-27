// <copyright file="RegisterMemberHandlerTests.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using Moq;
using Owens.Application.Members.Common;
using Owens.Application.Members.Register;
using Owens.Application.Members.Register.RegistrationChain;
using Owens.Contracts.Members.Register;
using Owens.Domain.Members;

namespace Owens.Tests.Application.Members
{
    /// <summary>
    /// Tests for the <see cref="RegisterMemberHandler"/> class.
    /// </summary>
    [TestClass]
    public class RegisterMemberHandlerTests
    {
        private readonly Mock<IMemberRepository> _memberRepository;
        private readonly RegisterMemberHandler _handler;

        /// <summary>
        /// Initializes a new instance of the <see cref="RegisterMemberHandlerTests"/> class.
        /// </summary>
        public RegisterMemberHandlerTests()
        {
            _memberRepository = new Mock<IMemberRepository>();
            _handler = new RegisterMemberHandler(_memberRepository.Object);
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

            _memberRepository.Setup(x => x.AddMember(It.IsAny<Member>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), CancellationToken.None))
                .ReturnsAsync(false);

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

            _memberRepository.Setup(x => x.AddMember(It.IsAny<Member>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), CancellationToken.None))
                .ReturnsAsync(true);

            var result = await _handler.Handle(new RegisterMemberRequest(), CancellationToken.None);

            Assert.IsNotNull(result.Response);
        }
    }
}
