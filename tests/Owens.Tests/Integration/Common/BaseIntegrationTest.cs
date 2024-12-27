// <copyright file="BaseIntegrationTest.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using System.Diagnostics;

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
                using (var context = IntegrationHelpers.GetTestApplicationContext())
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
                Debug.Write(exception);
                throw;
            }
        }
    }
}
