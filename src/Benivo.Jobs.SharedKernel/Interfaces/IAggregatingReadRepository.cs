using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.Specification;

namespace Benivo.Jobs.SharedKernel.Interfaces
{
    /// <summary>
    /// Repository interface containing aggregating operations (MaxBy, CountBy, etc...)
    /// </summary>
    /// <typeparam name="T">The type of the aggregate root entity</typeparam>
    public interface IAggregatingReadRepository<T> where T : class, IAggregateRoot
        // Server side group operation are not yet implemented by Ardalis.Specification, so pass expressions as a workaround
    {
        /// <summary>Returns the number of elements in each group specified by the grouping expression</summary>
        Task<IEnumerable<(TKey Key, int Count)>> CountByAsync<TKey>(
            Expression<Func<T, TKey>> groupExpression,
            ISpecification<T> specification,
            CancellationToken? token = null);

        Task<IEnumerable<(TKey Key, int Count)>> CountByNonZeroAsync<TKey>(
            Expression<Func<T, TKey>> groupExpression,
            ISpecification<T> specification,
            CancellationToken? token = null);
    }
}