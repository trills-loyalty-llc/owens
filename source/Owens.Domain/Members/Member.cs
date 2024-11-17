﻿// <copyright file="Member.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

namespace Owens.Domain.Members
{
    /// <summary>
    /// A customer represents an individual person who interacts with the loyalty platform.
    /// </summary>
    public class Member
    {
        /// <summary>
        /// Gets the identifier.
        /// </summary>
        public Guid Id { get; } = Guid.NewGuid();
    }
}
