// <copyright file="UserRepository.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Identity;
using Owens.Application.Common.Interfaces;
using Owens.Infrastructure.Identity.Models;

namespace Owens.Infrastructure.Identity.DataAccess
{
    /// <inheritdoc />
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<User> _userManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository"/> class.
        /// </summary>
        /// <param name="userManager">An instance of the <see cref="UserManager{TUser}"/> class.</param>
        public UserRepository(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        /// <inheritdoc/>
        public async Task<bool> AddUser(Guid id, string email, string username, string password)
        {
            var user = new User(id, email, username);

            var result = await _userManager.CreateAsync(user, password);

            return result.Succeeded;
        }
    }
}
