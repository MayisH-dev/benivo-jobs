namespace Benivo.Jobs.SharedKernel.Interfaces
{
    /// <summary>
    /// Marker interface for aggregate root entities
    /// </summary>
    /// <remarks>
    /// The parent entity for a certain portion of the
    /// domain that also handles interactions with its children
    /// </remarks>
    public interface IAggregateRoot { }
}