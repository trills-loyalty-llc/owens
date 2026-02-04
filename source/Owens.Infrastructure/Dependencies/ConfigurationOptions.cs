// <copyright file="ConfigurationOptions.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

namespace Owens.Infrastructure.Dependencies
{
    /// <summary>
    /// Configuration values that may be environment dependant.
    /// </summary>
    public class ConfigurationOptions
    {
        /// <summary>
        /// Gets the weather key.
        /// </summary>
        public string WeatherKey { get; init; } = string.Empty;
    }
}
