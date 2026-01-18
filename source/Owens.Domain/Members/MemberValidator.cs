// <copyright file="MemberValidator.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using FluentValidation;

namespace Owens.Domain.Members
{
    /// <inheritdoc />
    public class MemberValidator : AbstractValidator<Member>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MemberValidator"/> class.
        /// </summary>
        public MemberValidator()
        {
        }
    }
}
