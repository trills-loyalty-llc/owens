// <copyright file="RegisterMemberHandlerTests.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using MediatorBuddy;
using Moq;
using Owens.Application.Members.Common;
using Owens.Application.Members.Register;
using Owens.Contracts.Members.Register;
using Owens.Domain.Members;
using Owens.Domain.Users;

namespace Owens.Tests.Unit.Application.Members
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
            _memberRepository.Setup(x => x.AddMember(It.IsAny<Member>(), It.IsAny<UserInformation>(), CancellationToken.None))
                .ReturnsAsync(false);

            var result = await _handler.Handle(new RegisterMemberRequest(), CancellationToken.None);

            Assert.AreNotEqual(ApplicationStatus.Success, result.Status);
        }

        /// <summary>
        /// Handle, success, is correct.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task Handle_Success_IsCorrect()
        {
            _memberRepository.Setup(x => x.AddMember(It.IsAny<Member>(), It.IsAny<UserInformation>(), CancellationToken.None))
                .ReturnsAsync(true);

            var result = await _handler.Handle(new RegisterMemberRequest(), CancellationToken.None);

            Assert.AreEqual(ApplicationStatus.Success, result.Status);
        }
    }
}
