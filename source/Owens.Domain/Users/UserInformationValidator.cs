// <copyright file="UserInformationValidator.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using FluentValidation;

namespace Owens.Domain.Users
{
    /// <inheritdoc />
    public class UserInformationValidator : AbstractValidator<UserInformation>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserInformationValidator"/> class.
        /// </summary>
        public UserInformationValidator()
        {
        }
    }
}
