using System;
using MediatR;

namespace Benivo.Jobs.SharedKernel
{
    /// <summary>
    /// A base class for all domain events
    /// </summary>
    public abstract class BaseDomainEvent : INotification
    {
        public DateTime DateOccurred { get; protected set; } = DateTime.UtcNow;
    }
}