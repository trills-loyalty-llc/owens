// <copyright file="ITokenService.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using System.Security.Claims;

namespace Owens.Infrastructure.Identity.Services
{
    /// <summary>
    /// Interface for generating security tokens.
    /// </summary>
    public interface ITokenService
    {
        /// <summary>
        /// Generates an access token from a list of claims.
        /// </summary>
        /// <param name="claims">An <see cref="IEnumerable{T}"/> of <see cref="Claim"/>.</param>
        /// <returns>An access token for a client.</returns>
        string AccessToken(IEnumerable<Claim> claims);
    }
}
