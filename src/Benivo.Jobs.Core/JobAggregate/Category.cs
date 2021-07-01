using Ardalis.GuardClauses;
using Benivo.Jobs.SharedKernel;

namespace Benivo.Jobs.Core.JobAggregate
{
    public sealed class Category : BaseEntity
    {
        public Category(string title)
        {
            Title = Guard.Against.NullOrEmpty(title, nameof(title));
        }

        public string Title { get; private set; }
    }
}
