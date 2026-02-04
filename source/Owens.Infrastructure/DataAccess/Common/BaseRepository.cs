// <copyright file="BaseRepository.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using ClearDomain.GuidPrimary;
using Microsoft.EntityFrameworkCore;
using NMediation.Abstractions;
using Owens.Application.Common.DataAccess;
using Owens.Infrastructure.ErrorHandling;

namespace Owens.Infrastructure.DataAccess.Common
{
    /// <summary>
    /// Base class for all persistence repositories.
    /// </summary>
    /// <typeparam name="TAggregateRoot">The type of the aggregate root.</typeparam>
    public abstract class BaseRepository<TAggregateRoot> :
        IAddObject<TAggregateRoot>,
        IUpdateObject<TAggregateRoot>,
        IGetObjectById<TAggregateRoot>,
        IGetPagination<TAggregateRoot>,
        IGetAllObjects<TAggregateRoot>
        where TAggregateRoot : class, IAggregateRoot
    {
        private readonly IMediation _mediation;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseRepository{TAggregateRoot}"/> class.
        /// </summary>
        /// <param name="applicationContext">An instance of the <see cref="ApplicationContext"/> class.</param>
        /// <param name="mediation">An instance of the <see cref="IMediation"/> interface.</param>
        protected BaseRepository(ApplicationContext applicationContext, IMediation mediation)
        {
            Context = applicationContext;
            _mediation = mediation;
        }

        /// <summary>
        /// Gets the context.
        /// </summary>
        protected ApplicationContext Context { get; }

        /// <inheritdoc/>
        public async Task<PersistenceResult> AddObject(TAggregateRoot aggregateRoot, CancellationToken cancellationToken)
        {
            var result = await ExecuteCommand(
                set => set.AddAsync(aggregateRoot, cancellationToken).AsTask(),
                cancellationToken,
                aggregateRoot);

            return result > 0 ? PersistenceResult.Success(result) : PersistenceResult.Failure();
        }

        /// <inheritdoc/>
        public async Task<List<TAggregateRoot>> GetAllObjects(CancellationToken cancellationToken = default)
        {
            return await ExecuteQuery(dbSet => dbSet.ToListAsync(cancellationToken));
        }

        /// <inheritdoc/>
        public async Task<TAggregateRoot?> GetObjectById(Guid id, CancellationToken cancellationToken)
        {
            var result = await ExecuteQuery(
                set => set.Where(root => root.Id == id).ToListAsync(cancellationToken));

            return result.FirstOrDefault();
        }

        /// <inheritdoc />
        public async Task<PaginationResult<TAggregateRoot>> GetPaginatedRoots(PaginationQuery<TAggregateRoot> query, CancellationToken cancellationToken)
        {
            var totalCount = await Context.Set<TAggregateRoot>()
                .Where(query.Query)
                .CountAsync(cancellationToken);

            var resultList = await Context.Set<TAggregateRoot>()
                .Where(query.Query)
                .OrderBy(root => root.Id)
                .Skip(query.Skip)
                .Take(query.Take)
                .ToListAsync(cancellationToken);

            return new PaginationResult<TAggregateRoot>(resultList, totalCount);
        }

        /// <inheritdoc/>
        public async Task<int> UpdateObject(TAggregateRoot aggregateRoot, CancellationToken cancellationToken)
        {
            return await ExecuteCommand(
                dbSet =>
                {
                    dbSet.Update(aggregateRoot);

                    return Task.CompletedTask;
                },
                cancellationToken);
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
                await executionFunction.Invoke(Context.Set<TAggregateRoot>());

                var result = await Context.SaveChangesAsync(cancellationToken);

                if (result > 0)
                {
                    foreach (var aggregateRoot in aggregateRoots)
                    {
                        foreach (var occurrence in aggregateRoot.DomainEvents)
                        {
                            await _mediation.Publish(occurrence, cancellationToken);
                        }
                    }
                }

                return result;
            }
            catch (Exception exception)
            {
                await _mediation.Publish(GeneralExceptionOccurred.FromException(exception), cancellationToken);
            }

            return 0;
        }

        private async Task<List<TAggregateRoot>> ExecuteQuery(Func<DbSet<TAggregateRoot>, Task<List<TAggregateRoot>>> executionFunction)
        {
            try
            {
                return await executionFunction.Invoke(Context.Set<TAggregateRoot>());
            }
            catch (Exception)
            {
                return new List<TAggregateRoot>();
            }
        }
    }
}
