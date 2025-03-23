// <copyright file="LogResponse.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;
using Owens.Application.Common.Contracts;

namespace Owens.Infrastructure.Common.Logging.Common
{
    /// <inheritdoc />
    public class LogResponse : EntityResponse
    {
        private LogResponse(Guid id, DateTimeOffset timeStamp)
            : base(id)
        {
            TimeStamp = timeStamp;
        }

        /// <summary>
        /// Gets the log timestamp.
        /// </summary>
        [Required]
        public DateTimeOffset TimeStamp { get; init; }

        /// <summary>
        /// Instantiates a response from a <see cref="Log"/> object.
        /// </summary>
        /// <param name="log">A <see cref="Log"/> object.</param>
        /// <returns>A new response instance.</returns>
        public static LogResponse FromLog(Log log)
        {
            return new LogResponse(log.Id, log.DateTimeOffset);
        }
    }
}
