// <copyright file="Program.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using Owens.Infrastructure.Dependencies;
using Owens.Infrastructure.Identity.Models;
using Serilog;

namespace Owens.API
{
    /// <summary>
    /// Entry class for application.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Entry point for the application.
        /// </summary>
        /// <param name="args">A list of command arguments.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .WriteTo.Debug()
                .CreateBootstrapLogger();

            builder.Services.AddControllers();
            builder.Services.RegisterDependencies(builder.Configuration);
            builder.Services.AddAuthenticationDependencies(new TokenConfiguration(Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString()));
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            app.UseSerilogRequestLogging();

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseAuthentication();

            app.MapControllers();

            app.UseCors(policyBuilder => policyBuilder.AllowAnyHeader().AllowAnyHeader().AllowAnyOrigin());

            await app.RunAsync();
        }
    }
}
