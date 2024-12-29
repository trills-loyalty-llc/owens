// <copyright file="TokenService.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Owens.Infrastructure.Identity.Models;

namespace Owens.Infrastructure.Identity.Services
{
    /// <inheritdoc />
    public class TokenService : ITokenService
    {
        private readonly TimeProvider _timeProvider;
        private readonly TokenConfiguration _tokenConfiguration;

        /// <summary>
        /// Initializes a new instance of the <see cref="TokenService"/> class.
        /// </summary>
        /// <param name="timeProvider">An instance of the <see cref="TimeProvider"/> class.</param>
        /// <param name="tokenConfiguration">An instance of the <see cref="TokenConfiguration"/> class.</param>
        public TokenService(TimeProvider timeProvider, TokenConfiguration tokenConfiguration)
        {
            _timeProvider = timeProvider;
            _tokenConfiguration = tokenConfiguration;
        }

        /// <inheritdoc/>
        public string AccessToken(IEnumerable<Claim> claims)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenConfiguration.Key));

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                _tokenConfiguration.Issuer,
                _tokenConfiguration.Audience,
                claims,
                _timeProvider.GetUtcNow().UtcDateTime,
                _timeProvider.GetUtcNow().UtcDateTime.AddMinutes(30),
                credentials);

            return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        }
    }
}
