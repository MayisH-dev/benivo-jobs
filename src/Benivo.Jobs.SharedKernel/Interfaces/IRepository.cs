using Ardalis.Specification;

namespace Benivo.Jobs.SharedKernel.Interfaces
{
    /// <summary>
    /// Repository pattern interface, a persistence implementation agnostic abstraction over data access
    /// </summary>
    /// <typeparam name="T">The type of the aggregate root entity</typeparam>
    public interface IRepository<T> : IRepositoryBase<T> where T : class, IAggregateRoot { }
}