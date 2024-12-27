// <copyright file="BaseIntegrationTest.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

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
            using (var context = IntegrationHelpers.GetTestApplicationContext())
            {
                context.Database.EnsureDeleted();

                context.Database.EnsureCreated();
            }

            using (var context = IntegrationHelpers.GetTestIdentityContext())
            {
                context.Database.EnsureDeleted();

                context.Database.EnsureCreated();
            }
        }
    }
}
