// <copyright file="Envelope.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

namespace Owens.Application.Common.Mediation
{
    /// <summary>
    /// Temp envelope.
    /// </summary>
    /// <typeparam name="TResponse">The type of the response.</typeparam>
    public class Envelope<TResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Envelope{TResponse}"/> class.
        /// </summary>
        /// <param name="response">The response object.</param>
        public Envelope(TResponse response)
        {
            Response = response;
        }

        /// <summary>
        /// Gets the response object.
        /// </summary>
        public TResponse Response { get; }
    }
}
