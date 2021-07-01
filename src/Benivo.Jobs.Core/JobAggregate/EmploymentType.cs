using Benivo.Jobs.SharedKernel;

namespace Benivo.Jobs.Core.JobAggregate
{
    public sealed class EmploymentType : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
    }
}
