// <copyright file="UserFactory.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using Owens.Contracts.Users.Register;
using Owens.Domain.Users;

namespace Owens.Application.Users.Common
{
    /// <summary>
    /// Factory methods for the <see cref="UserInformation"/> class.
    /// </summary>
    public static class UserFactory
    {
        /// <summary>
        /// Instantiates a user information object.
        /// </summary>
        /// <param name="request">A <see cref="RegisterUserRequest"/> object.</param>
        /// <returns>A <see cref="UserInformation"/> instance.</returns>
        public static UserInformation UserInformation(RegisterUserRequest request)
        {
            return new UserInformation(request.Email, request.Username, request.Password);
        }
    }
}
