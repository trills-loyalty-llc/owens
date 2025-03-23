// <copyright file="GlobalExceptionOccurredHandler.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using MediatorBuddy;
using MediatR;

namespace Owens.Infrastructure.ErrorHandling
{
    /// <inheritdoc />
    public class GlobalExceptionOccurredHandler : INotificationHandler<GlobalExceptionOccurred>
    {
        /// <inheritdoc/>
        public Task Handle(GlobalExceptionOccurred notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
