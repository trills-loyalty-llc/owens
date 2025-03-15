// <copyright file="BaseRepository.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using MediatR;
using Microsoft.EntityFrameworkCore;
using Owens.Application.Common.DataAccess;
using Owens.Domain.Common;

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

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseRepository{TAggregateRoot}"/> class.
        /// </summary>
        /// <param name="publisher">An instance of the <see cref="IPublisher"/> interface.</param>
        /// <param name="applicationContext">An instance of the <see cref="ApplicationContext"/> class.</param>
        protected BaseRepository(IPublisher publisher, ApplicationContext applicationContext)
        {
            _publisher = publisher;
            ApplicationContext = applicationContext;
        }

        /// <summary>
        /// Gets the application context.
        /// </summary>
        protected ApplicationContext ApplicationContext { get; }

        /// <inheritdoc/>
        public async Task<bool> AddObject(TAggregateRoot aggregateRoot, CancellationToken cancellationToken)
        {
            await ApplicationContext.Set<TAggregateRoot>().AddAsync(aggregateRoot, cancellationToken);

            var result = await ApplicationContext.SaveChangesAsync(cancellationToken);

            if (result > 0)
            {
                await PublishEvents(new List<IAggregateRoot> { aggregateRoot }, cancellationToken);

                return true;
            }

            return false;
        }

        /// <inheritdoc/>
        public async Task<TAggregateRoot?> GetObjectById(Guid id, CancellationToken cancellationToken)
        {
            return await ApplicationContext
                .Set<TAggregateRoot>()
                .FirstOrDefaultAsync(aggregateRoot => aggregateRoot.Id == id, cancellationToken);
        }

        /// <summary>
        /// Publishes all events from a list of <see cref="IAggregateRoot"/> objects.
        /// </summary>
        /// <param name="aggregateRoots">A list of <see cref="IAggregateRoot"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        protected async Task PublishEvents(IEnumerable<IAggregateRoot> aggregateRoots, CancellationToken cancellationToken)
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
