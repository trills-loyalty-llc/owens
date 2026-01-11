// <copyright file="BaseRepository.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using ClearDomain.GuidPrimary;
using Microsoft.EntityFrameworkCore;
using Owens.Application.Common.DataAccess;

namespace Owens.Infrastructure.DataAccess.Common
{
    /// <summary>
    /// Base class for all persistence repositories.
    /// </summary>
    /// <typeparam name="TAggregateRoot">The type of the aggregate root.</typeparam>
    public abstract class BaseRepository<TAggregateRoot> :
        IAddObject<TAggregateRoot>,
        IGetObjectById<TAggregateRoot>,
        IGetPagination<TAggregateRoot>
        where TAggregateRoot : class, IAggregateRoot
    {
        private readonly ApplicationContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseRepository{TAggregateRoot}"/> class.
        /// </summary>
        /// <param name="applicationContext">An instance of the <see cref="ApplicationContext"/> class.</param>
        protected BaseRepository(ApplicationContext applicationContext)
        {
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

        /// <inheritdoc />
        public async Task<PaginationResult<TAggregateRoot>> GetPaginatedRoots(PaginationQuery<TAggregateRoot> query, CancellationToken cancellationToken)
        {
            var totalCount = await _context.Set<TAggregateRoot>()
                .Where(query.Query)
                .CountAsync(cancellationToken);

            var resultList = await _context.Set<TAggregateRoot>()
                .Where(query.Query)
                .Skip(query.Skip)
                .Take(query.Take)
                .ToListAsync(cancellationToken);

            return new PaginationResult<TAggregateRoot>(resultList, totalCount);
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

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async Task<List<TAggregateRoot>> ExecuteQuery(Func<DbSet<TAggregateRoot>, Task<List<TAggregateRoot>>> executionFunction, CancellationToken cancellationToken)
        {
            try
            {
                return await executionFunction.Invoke(_context.Set<TAggregateRoot>());
            }
            catch (Exception)
            {
                return new List<TAggregateRoot>();
            }
        }
    }
}
