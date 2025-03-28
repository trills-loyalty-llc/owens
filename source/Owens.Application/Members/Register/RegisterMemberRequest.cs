﻿// <copyright file="RegisterMemberRequest.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using MediatorBuddy;
using Owens.Application.Users.Register;

namespace Owens.Application.Members.Register
{
    /// <inheritdoc cref="RegisterUserRequest" />
    public class RegisterMemberRequest : RegisterUserRequest, IEnvelopeRequest<RegisterMemberResponse>
    {
    }
}
