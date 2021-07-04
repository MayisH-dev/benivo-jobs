using Benivo.Jobs.SharedKernel;

namespace Benivo.Jobs.Core.JobAggregate
{
    public sealed class Bookmark : BaseEntity
    {
        // Convention based efcore config requires this to be not nullable to be required
        // Constructor binding on navigation properties is not yet supported in efcore 5
        // So just ignore this warning for now
        public Job Job { get; set; }
    }
}
