// <copyright file="AuthenticationRegistration.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Owens.Infrastructure.DataAccess.Common;
using Owens.Infrastructure.Identity.Models;
using Owens.Infrastructure.Identity.Services;

namespace Owens.Infrastructure.Dependencies
{
    /// <summary>
    /// Registration class for MemberController.
    /// </summary>
    public static class AuthenticationRegistration
    {
        /// <summary>
        /// Registers all Authentication based dependencies.
        /// </summary>
        /// <param name="services">An instance of the <see cref="IServiceCollection"/> interface.</param>
        /// <param name="tokenConfiguration">An instance of the <see cref="TokenConfiguration"/> class.</param>
        public static void AddAuthenticationDependencies(this IServiceCollection services, TokenConfiguration tokenConfiguration)
        {
            services.AddIdentity<User, IdentityRole<Guid>>()
                .AddEntityFrameworkStores<ApplicationContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.Password.RequiredLength = PasswordRequirements.MinimumPasswordLength;
            });

            services.AddAuthorization();

            services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;

                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = true,
                        ValidateIssuer = true,
                        ValidAudience = tokenConfiguration.Audience,
                        ValidIssuer = tokenConfiguration.Issuer,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenConfiguration.Key)),
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero,
                    };
                });

            services.AddTransient<ITokenService, TokenService>();
        }
    }
}
