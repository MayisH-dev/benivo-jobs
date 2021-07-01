using Benivo.Jobs.SharedKernel;

namespace Benivo.Jobs.Core.JobAggregate.Events
{
    public sealed class JobBookmarkedEvent : BaseDomainEvent
    {
        public JobBookmarkedEvent(Job job) => Job = job;
        public Job Job { get; }
    }
}
