using Benivo.Jobs.SharedKernel;

namespace Benivo.Jobs.Core.JobAggregate
{
    public sealed class Bookmark : BaseEntity
    {
        public Job Job { get; set; }
    }
}
