// <copyright file="ClientValidator.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using FluentValidation;

namespace Owens.Domain.Clients
{
    /// <inheritdoc />
    public class ClientValidator : AbstractValidator<Client>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClientValidator"/> class.
        /// </summary>
        public ClientValidator()
        {
        }
    }
}
