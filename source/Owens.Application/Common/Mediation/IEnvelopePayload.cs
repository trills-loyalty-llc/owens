// <copyright file="IEnvelopePayload.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using NMediation.Abstractions;

namespace Owens.Application.Common.Mediation
{
    /// <inheritdoc />
    public interface IEnvelopePayload<TResponse> : IPayload<Envelope<TResponse>>
    {
    }
}
