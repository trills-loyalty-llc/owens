// <copyright file="AssemblyConstants.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using System.Reflection;

namespace Owens.Infrastructure.Dependencies
{
    /// <summary>
    /// A list of constants for assemblies.
    /// </summary>
    internal static class AssemblyConstants
    {
        /// <summary>
        /// Returns the application assembly for registration.
        /// </summary>
        public static readonly Assembly Application = Assembly.Load("Owens.Application");

        /// <summary>
        /// Returns the infrastructure assembly for registration.
        /// </summary>
        public static readonly Assembly Infrastructure = Assembly.GetExecutingAssembly();
    }
}
