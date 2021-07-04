using System.Linq;
using Ardalis.Specification;

namespace Benivo.Jobs.Core.JobAggregate.Specifications
{
    public sealed class JobDetailsByIdSpecification : Specification<Job>, ISingleResultSpecification
    {
        public JobDetailsByIdSpecification(int id)
        {
            Query
                .AsNoTracking()
                .Where(j => j.Id == id)
                .Include(j => j.Bookmark)
                .Include(j => j.JobLocation)
                .Include(j => j.EmploymentType)
                .Include(j => j.Category)
                .Include(j => j.Company);
        }
    }
}
