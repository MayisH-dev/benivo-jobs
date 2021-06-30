using System.Collections.Generic;
using System.Linq;

namespace Benivo.Jobs.SharedKernel
{
    /// <summary>
    /// A base class for all database entities
    /// </summary>
    public abstract class BaseEntity
    {
        private List<BaseDomainEvent>? _events;

        public int Id { get; set; }

        /// <summary>
        /// The collection of domain events associated with the entity
        /// </summary>
        public IEnumerable<BaseDomainEvent> Events => _events ?? Enumerable.Empty<BaseDomainEvent>();

        /// <summary>
        /// Add a domain event to the given entity, which will be handled before persisting changes
        /// </summary>
        /// <param name="domainEvent"></param>
        public void AddDomainEvent(BaseDomainEvent domainEvent)
        {
            _events ??= new();
            _events.Add(domainEvent);
        }

        public void ClearDomainEvents() =>
            _events?.Clear();
    }
}