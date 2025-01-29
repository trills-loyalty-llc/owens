// <copyright file="HealthCheckRequestHandlerTests.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using MediatorBuddy;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Moq;
using Owens.Infrastructure.Common.HealthChecks;
using Owens.Infrastructure.HealthChecks;
using Owens.Tests.Integration.Common;

namespace Owens.Tests.Integration.Infrastructure.HealthChecks
{
    /// <inheritdoc />
    [TestClass]
    public class HealthCheckRequestHandlerTests : BaseIntegrationTest
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
        public async Task Handle_IsSuccessful()
        {
            _healthCheckService.Setup(x => x.HealthCheckAsync(CancellationToken.None))
                .ReturnsAsync(new HealthReport(new Dictionary<string, HealthReportEntry>(), TimeSpan.Zero));

            var handler = new HealthCheckRequestHandler(_healthCheckService.Object);

            var result = await handler.Handle(new HealthCheckRequest(), CancellationToken.None);

            Assert.AreEqual(ApplicationStatus.Success, result.Status);
        }
    }
}
