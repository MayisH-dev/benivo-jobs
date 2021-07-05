using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Benivo.Jobs.SharedKernel.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Benivo.Jobs.Infrastructure.Data
{
    public sealed class EfRepository<T>
        : RepositoryBase<T>,
        IReadRepository<T>,
        IRepository<T>,
        IAggregatingReadRepository<T>
        where T : class, IAggregateRoot
    {
        private readonly AppDbContext _dbContext;
        public EfRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<(TKey Key, int Count)>> CountByAsync<TKey>(
            Expression<Func<T, TKey>> groupExpression,
            ISpecification<T> specification,
            CancellationToken? token = null) =>
            await GroupQuery(groupExpression, specification)
                .Select(g =>
                    new ValueTuple<TKey, int>(
                        g.Key,
                        g.Count()))
                .ToArrayAsync(token ?? default);

        public async Task<IEnumerable<(TKey Key, int Count)>> CountByNonZeroAsync<TKey>(
            Expression<Func<T, TKey>> groupExpression,
            ISpecification<T> specification,
            CancellationToken? token = null) =>
            await GroupQuery(groupExpression, specification)
                .Where(g => g.Count() > 0)
                .Select(g =>
                    new ValueTuple<TKey, int>(
                        g.Key,
                        g.Count()))
                .ToArrayAsync(token ?? default);

        private IQueryable<IGrouping<TKey, T>> GroupQuery<TKey>(Expression<Func<T, TKey>> groupExpression, ISpecification<T> specification) =>
            _dbContext.Set<T>()
                .WithSpecification(specification)
                .GroupBy(groupExpression);
    }
}
