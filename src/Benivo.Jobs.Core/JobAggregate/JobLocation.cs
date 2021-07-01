using Ardalis.GuardClauses;
using Benivo.Jobs.SharedKernel;

namespace Benivo.Jobs.Core.JobAggregate
{
    public sealed class JobLocation : BaseEntity
    {
        public JobLocation(string location)
        {
            Location = Guard.Against.NullOrEmpty(location, nameof(location));
        }

        public string Location { get; private set; }
    }
}
