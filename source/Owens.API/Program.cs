// <copyright file="Program.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using Owens.Infrastructure.Dependencies;
using Serilog;
using System.Reflection;

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
            builder.Services.RegisterJobs();
            builder.Services.RegisterDependencies(builder.Configuration);
            builder.Services.AddAuthenticationDependencies(builder.Configuration);
            builder.Services.AddSwaggerGen(options =>
            {
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);
            });

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
