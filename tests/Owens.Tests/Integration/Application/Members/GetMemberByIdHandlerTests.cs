// <copyright file="GetMemberByIdHandlerTests.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using MediatR;
using Microsoft.AspNetCore.Identity;
using Owens.Application.Members.GetById;
using Owens.Contracts.Members.GetById;
using Owens.Domain.Members;
using Owens.Infrastructure.DataAccess.Common;
using Owens.Infrastructure.DataAccess.Members;
using Owens.Infrastructure.Identity.Models;
using Owens.Tests.Integration.Common;

namespace Owens.Tests.Integration.Application.Members
{
    [TestClass]
    public class GetMemberByIdHandlerTests
    {
        /// <summary>
        /// Handle, success, is correct.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task Handle_Success_IsCorrectAsync()
        {
            await IntegrationHelpers.ClearTablesAsync();

            var id = Guid.NewGuid();

            await using (var context = new ApplicationContext(IntegrationHelpers.GetApplicationOptions()))
            {
                await context.Members.AddAsync(new Member(id));

                await context.SaveChangesAsync();
            }

            await using (var context = new ApplicationContext(IntegrationHelpers.GetApplicationOptions()))
            {
                var handler = new GetMemberByIdHandler(
                    new MemberRepository(
                        IntegrationHelpers.GetService<IPublisher>(),
                        context,
                        IntegrationHelpers.GetService<UserManager<User>>()));

                var response = await handler.Handle(new GetMemberByIdRequest(id), CancellationToken.None);

                Assert.AreEqual(id, response.Response.Id);
            }
        }
    }
}
