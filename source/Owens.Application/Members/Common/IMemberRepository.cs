// <copyright file="IMemberRepository.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using Owens.Application.Common.Interfaces;
using Owens.Domain.Members;

namespace Owens.Application.Members.Common
{
    /// <summary>
    /// Interface for interacting with <see cref="Member"/> persistence.
    /// </summary>
    public interface IMemberRepository
        : IAddObject<Member>
    {
    }
}
