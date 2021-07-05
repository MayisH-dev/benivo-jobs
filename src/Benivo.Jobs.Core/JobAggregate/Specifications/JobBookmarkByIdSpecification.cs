using System.Linq;
using Ardalis.Specification;

namespace Benivo.Jobs.Core.JobAggregate.Specifications
{
    public sealed class JobBookmarkByIdSpecification : Specification<Job>, ISingleResultSpecification
    {
        public JobBookmarkByIdSpecification(int id)
        {
            Query
                .Where(j => j.Id == id)
                .Include(j => j.Bookmark);
        }
    }
}
