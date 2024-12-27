// <copyright file="GetMemberByIdHandlerTests.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using Moq;
using Owens.Application.Members.Common;
using Owens.Application.Members.GetById;
using Owens.Contracts.Members.GetById;
using Owens.Domain.Members;

namespace Owens.Tests.Application.Members
{
    /// <summary>
    /// Tests for the <see cref="GetMemberByIdHandler"/> class.
    /// </summary>
    [TestClass]
    public class GetMemberByIdHandlerTests
    {
        private readonly Mock<IMemberRepository> _memberRepository;
        private readonly GetMemberByIdHandler _handler;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetMemberByIdHandlerTests"/> class.
        /// </summary>
        public GetMemberByIdHandlerTests()
        {
            _memberRepository = new Mock<IMemberRepository>();
            _handler = new GetMemberByIdHandler(_memberRepository.Object);
        }

        /// <summary>
        /// Handle, success, is correct.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [TestMethod]
        public async Task Handle_Success_IsCorrect()
        {
            _memberRepository.Setup(x => x.GetObjectById(It.IsAny<Guid>(), CancellationToken.None))
                .ReturnsAsync(new Member());

            var result = await _handler.Handle(new GetMemberByIdRequest(Guid.NewGuid()), CancellationToken.None);

            Assert.IsNotNull(result.Response);
        }
    }
}
