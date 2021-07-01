using Benivo.Jobs.SharedKernel;

namespace Benivo.Jobs.Core.JobAggregate
{
    public sealed class JobLocation : BaseEntity
    {
        public string Location { get; set; } = string.Empty;
    }
}
