﻿// <copyright file="BaseIntegrationTest.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using Owens.Infrastructure.DataAccess.Common;
using Owens.Infrastructure.Identity.DataAccess;

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
            using (var context = new IdentityContext(IntegrationHelpers.GetIdentityOptions()))
            {
                context.Database.EnsureDeleted();

                context.Database.EnsureCreated();
            }

            using (var context = new ApplicationContext(IntegrationHelpers.GetApplicationOptions()))
            {
                context.Database.EnsureDeleted();

                context.Database.EnsureCreated();
            }
        }
    }
}
