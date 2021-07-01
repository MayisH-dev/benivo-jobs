using Benivo.Jobs.SharedKernel;

namespace Benivo.Jobs.Core.JobAggregate
{
    public sealed class Category : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
    }
}
