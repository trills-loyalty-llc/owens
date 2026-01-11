// <copyright file="HealthCheckRequestHandlerTests.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using Moq;
using Owens.Infrastructure.HealthChecks;

namespace Owens.Tests.Unit.Infrastructure.HealthChecks
{
    /// <summary>
    /// Tests for the <see cref="IHealthCheckService"/> class.
    /// </summary>
    [TestClass]
    public class HealthCheckRequestHandlerTests
    {
        private readonly Mock<IHealthCheckService> _healthCheckService;

        /// <summary>
        /// Initializes a new instance of the <see cref="HealthCheckRequestHandlerTests"/> class.
        /// </summary>
        public HealthCheckRequestHandlerTests()
        {
            _healthCheckService = new Mock<IHealthCheckService>();
        }

        /// <summary>
        /// Handler can retrieve health status successfully.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public Task Handle_IsSuccessful()
        {
            return Task.CompletedTask;
        }
    }
}
