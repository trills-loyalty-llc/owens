// <copyright file="BaseRepository.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using ClearDomain.GuidPrimary;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Owens.Application.Common.Interfaces;

namespace Owens.Infrastructure.DataAccess.Common
{
    /// <summary>
    /// Base class for all persistence repositories.
    /// </summary>
    /// <typeparam name="TAggregateRoot">The type of the aggregate root.</typeparam>
    public abstract class BaseRepository<TAggregateRoot> :
        IAddObject<TAggregateRoot>,
        IGetObjectById<TAggregateRoot>
        where TAggregateRoot : class, IAggregateRoot
    {
        private readonly IPublisher _publisher;
        private readonly ApplicationContext _applicationContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseRepository{TAggregateRoot}"/> class.
        /// </summary>
        /// <param name="publisher">An instance of the <see cref="IPublisher"/> interface.</param>
        /// <param name="applicationContext">An instance of the <see cref="ApplicationContext"/> class.</param>
        protected BaseRepository(IPublisher publisher, ApplicationContext applicationContext)
        {
            _publisher = publisher;
            _applicationContext = applicationContext;
        }

        /// <inheritdoc/>
        public async Task<bool> AddObject(TAggregateRoot aggregateRoot, CancellationToken cancellationToken)
        {
            await _applicationContext.Set<TAggregateRoot>().AddAsync(aggregateRoot, cancellationToken);

            var result = await _applicationContext.SaveChangesAsync(cancellationToken);

            if (result > 0)
            {
                await PublishEvent(new List<IAggregateRoot> { aggregateRoot }, cancellationToken);

                return true;
            }

            return false;
        }

        /// <inheritdoc/>
        public async Task<TAggregateRoot?> GetObjectById(Guid id, CancellationToken cancellationToken)
        {
            return await _applicationContext
                .Set<TAggregateRoot>()
                .FirstOrDefaultAsync(aggregateRoot => aggregateRoot.Id == id, cancellationToken);
        }

        private async Task PublishEvent(IEnumerable<IAggregateRoot> aggregateRoots, CancellationToken cancellationToken)
        {
            foreach (var aggregateRoot in aggregateRoots)
            {
                foreach (var domainEvent in aggregateRoot.DomainEvents)
                {
                    await _publisher.Publish(domainEvent, cancellationToken);
                }
            }
        }
    }
}
