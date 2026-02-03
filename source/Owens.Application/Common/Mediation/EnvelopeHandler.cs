// <copyright file="EnvelopeHandler.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using NMediation.Abstractions;

namespace Owens.Application.Common.Mediation
{
    /// <inheritdoc />
    public abstract class EnvelopeHandler<TRequest, TResponse> : IEnvelopeHandler<TRequest, TResponse>
        where TRequest : IPayload<Envelope<TResponse>>
    {
        /// <inheritdoc/>
        public abstract Task<Envelope<TResponse>> Handle(TRequest payload, CancellationToken cancellationToken);

        /// <summary>
        /// Success result.
        /// </summary>
        /// <param name="response">The response type.</param>
        /// <returns>An <see cref="Envelope{T}"/>.</returns>
        protected Envelope<TResponse> Success(TResponse response)
        {
            return new Envelope<TResponse>(response);
        }
    }
}
