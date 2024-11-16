// <copyright file="Program.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using Owens.Infrastructure.Dependencies;

namespace Owens.API
{
    /// <summary>
    /// Entry class for the application.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Static method for application initialization.
        /// </summary>
        /// <param name="args">A params of command line arguments.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.RegisterDependencies();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            await app.RunAsync();
        }
    }
}
