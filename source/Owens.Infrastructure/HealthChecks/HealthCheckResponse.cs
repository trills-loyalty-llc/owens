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
           Entries = healthReport.Entries
               .Select(pair => KeyValuePair.Create(pair.Key, HealthReportEntryResponse.FromEntry(pair.Value)))
               .ToDictionary();
           TotalDuration = healthReport.TotalDuration;
           Status = healthReport.Status;
       }

       /// <summary>
       /// Gets the health report entries.
       /// </summary>
       [Required]
       public IDictionary<string, HealthReportEntryResponse> Entries { get; init; }

        /// <summary>
        /// Gets the total health check duration.
        /// </summary>
       [Required]
       public TimeSpan TotalDuration { get; init; }

        /// <summary>
        /// Gets the total health status.
        /// </summary>
       [Required]
       public HealthStatus Status { get; init; }

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
