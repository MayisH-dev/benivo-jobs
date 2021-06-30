using Ardalis.Specification;

namespace Benivo.Jobs.SharedKernel.Interfaces
{
    /// <summary>
    /// Repository pattern interface, a persistence implementation agnostic abstraction over data access
    /// Does not support data mutation operation
    /// </summary>
    /// <typeparam name="T">The type of the aggregate root entity</typeparam>
    public interface IReadRepository<T> : IReadRepositoryBase<T> where T : class, IAggregateRoot { }
}