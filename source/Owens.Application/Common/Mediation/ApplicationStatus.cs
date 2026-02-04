// <copyright file="ApplicationStatus.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

namespace Owens.Application.Common.Mediation
{
    /// <summary>
    /// Status codes for the application.
    /// </summary>
    public static class ApplicationStatus
    {
        /// <summary>
        /// Successful operation.
        /// </summary>
        public const int Success = 1;

        /// <summary>
        /// Validation failed during the operation.
        /// </summary>
        public const int ValidationFailed = 2;

        /// <summary>
        /// None descriptive failure.
        /// </summary>
        public const int GeneralFailure = 3;
    }
}
