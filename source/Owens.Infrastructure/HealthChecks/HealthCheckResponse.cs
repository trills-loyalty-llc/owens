// <copyright file="HealthCheckResponse.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Owens.Infrastructure.HealthChecks
{
    /// <summary>
    /// Response class for a health check.
    /// </summary>
    public class HealthCheckResponse
    {
       private HealthCheckResponse(HealthReport healthReport)
       {
            HealthReport = healthReport;
       }

        /// <summary>
        /// Gets the health report.
        /// </summary>
       [Required]
       public HealthReport HealthReport { get; }

       /// <summary>
       /// Instantiates a response for a health check.
       /// </summary>
       /// <param name="healthReport">A <see cref="HealthReport"/> class.</param>
       /// <returns>A new instance of a <see cref="HealthCheckResponse"/>.</returns>
       public static HealthCheckResponse FromReport(HealthReport healthReport)
       {
           return new HealthCheckResponse(healthReport);
       }
    }
}
