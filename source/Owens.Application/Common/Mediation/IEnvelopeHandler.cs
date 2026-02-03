// <copyright file="IEnvelopeHandler.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using NMediation.Abstractions;

namespace Owens.Application.Common.Mediation
{
    /// <inheritdoc />
    public interface IEnvelopeHandler<in TRequest, TResponse> : IPayloadHandler<TRequest, Envelope<TResponse>>
        where TRequest : IPayload<Envelope<TResponse>>
    {
    }
}
