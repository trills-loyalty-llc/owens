// <copyright file="BaseRepository.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using MediatorBuddy;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Owens.Application.Common.DataAccess;
using Owens.Domain.Common;
using Owens.Infrastructure.ErrorHandling;

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

        private readonly ApplicationContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseRepository{TAggregateRoot}"/> class.
        /// </summary>
        /// <param name="publisher">An instance of the <see cref="IPublisher"/> interface.</param>
        /// <param name="applicationContext">An instance of the <see cref="ApplicationContext"/> class.</param>
        protected BaseRepository(IPublisher publisher, ApplicationContext applicationContext)
        {
            _publisher = publisher;
            _context = applicationContext;
        }

        /// <inheritdoc/>
        public async Task<int> AddObject(TAggregateRoot aggregateRoot, CancellationToken cancellationToken)
        {
            return await ExecuteCommand(
                set => set.AddAsync(aggregateRoot, cancellationToken).AsTask(),
                cancellationToken,
                aggregateRoot);
        }

        /// <inheritdoc/>
        public async Task<TAggregateRoot?> GetObjectById(Guid id, CancellationToken cancellationToken)
        {
            var result = await ExecuteQuery(
                set => set.Where(root => root.Id == id).ToListAsync(cancellationToken),
                cancellationToken);

            return result.FirstOrDefault();
        }

        /// <summary>
        /// Performs a command operation.
        /// </summary>
        /// <param name="executionFunction">A <see cref="Func{TResult}"/> to execute.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <param name="aggregateRoots">A <see cref="IEnumerable{T}"/> of roots.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        protected async Task<int> ExecuteCommand(Func<DbSet<TAggregateRoot>, Task> executionFunction, CancellationToken cancellationToken, params TAggregateRoot[] aggregateRoots)
        {
            try
            {
                await executionFunction.Invoke(_context.Set<TAggregateRoot>());

                var result = await _context.SaveChangesAsync(cancellationToken);

                if (result > 0)
                {
                    foreach (var aggregateRoot in aggregateRoots)
                    {
                        foreach (var domainEvent in aggregateRoot.DomainEvents)
                        {
                            await _publisher.Publish(domainEvent, cancellationToken);
                        }
                    }

                    return ApplicationStatus.Success;
                }

                return ApplicationStatus.GeneralError;
            }
            catch (Exception exception)
            {
                await _publisher.Publish(GeneralExceptionOccurred.FromException(exception), cancellationToken);

                return ApplicationStatus.GeneralError;
            }
        }

        private async Task<List<TAggregateRoot>> ExecuteQuery(Func<DbSet<TAggregateRoot>, Task<List<TAggregateRoot>>> executionFunction, CancellationToken cancellationToken)
        {
            try
            {
                return await executionFunction.Invoke(_context.Set<TAggregateRoot>());
            }
            catch (Exception exception)
            {
                await _publisher.Publish(GeneralExceptionOccurred.FromException(exception), cancellationToken);

                return new List<TAggregateRoot>();
            }
        }
    }
}
