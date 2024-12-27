// <copyright file="BaseIntegrationTest.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Owens.Infrastructure.DataAccess.Common;

namespace Owens.Tests.Integration.Common
{
    /// <summary>
    /// Base class for all integration tests.
    /// </summary>
    public abstract class BaseIntegrationTest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseIntegrationTest"/> class.
        /// </summary>
        protected BaseIntegrationTest()
        {
            try
            {
                var applicationBuilder = new DbContextOptionsBuilder<ApplicationContext>();
                applicationBuilder.UseSqlServer(IntegrationHelpers.GetApplicationConnectionString());

                using (var context = new ApplicationContext(applicationBuilder.Options))
                {
                    context.Members.RemoveRange(context.Members);

                    context.SaveChanges();
                }

                using (var context = IntegrationHelpers.GetTestIdentityContext())
                {
                    context.Users.RemoveRange(context.Users);

                    context.SaveChanges();
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }
    }
}
