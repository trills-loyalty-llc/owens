// <copyright file="IUserRepository.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

namespace Owens.Application.Common.Interfaces
{
    /// <summary>
    /// Interface for interacting with users.
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Adds a user to the persistence model.
        /// </summary>
        /// <param name="id">The identifier for the user.</param>
        /// <param name="email">The email for the user.</param>
        /// <param name="username">The username for the user.</param>
        /// <param name="password">The user password.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<bool> AddUser(Guid id, string email, string username, string password);
    }
}
