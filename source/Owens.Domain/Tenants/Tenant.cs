// <copyright file="Tenant.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Identity;

namespace Owens.Domain.Tenants
{
    /// <inheritdoc />
    public class Tenant : IdentityUser<Guid>
    {
    }
}
