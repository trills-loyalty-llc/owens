// <copyright file="HealthReportEntryResponse.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Owens.Infrastructure.HealthChecks
{
    /// <summary>
    /// Response class for a health report entry.
    /// </summary>
    public class HealthReportEntryResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HealthReportEntryResponse"/> class.
        /// </summary>
        /// <param name="entry">A <see cref="HealthReportEntry"/> object.</param>
        private HealthReportEntryResponse(HealthReportEntry entry)
        {
            Data = entry.Data.ToDictionary();
            Description = entry.Description ?? string.Empty;
            Duration = entry.Duration;
            Status = entry.Status;
            Tags = entry.Tags;
        }

        /// <summary>
        /// Gets the entry data.
        /// </summary>
        [Required]
        public IDictionary<string, object> Data { get; }

        /// <summary>
        /// Gets the entry description.
        /// </summary>
        [Required]
        public string Description { get; }

        /// <summary>
        /// Gets the duration to retrieve the entry.
        /// </summary>
        [Required]
        public TimeSpan Duration { get; }

        /// <summary>
        /// Gets the status of the entry.
        /// </summary>
        [Required]
        public HealthStatus Status { get; }

        /// <summary>
        /// Gets the tags associated with the entry.
        /// </summary>
        [Required]
        public IEnumerable<string> Tags { get; }

        /// <summary>
        /// Static creation method.
        /// </summary>
        /// <param name="entry">A <see cref="HealthReportEntry"/> object.</param>
        /// <returns>A new <see cref="HealthReportEntryResponse"/> object.</returns>
        public static HealthReportEntryResponse FromEntry(HealthReportEntry entry)
        {
            return new HealthReportEntryResponse(entry);
        }
    }
}
