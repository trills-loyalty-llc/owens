// <copyright file="IdentityEntity.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Identity;

namespace Owens.Domain.Common
{
    /// <inheritdoc />
    public abstract class IdentityEntity : IdentityUser<Guid>
    {
    }
}
