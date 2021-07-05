using System.Collections.Generic;
using System.Linq;
using Ardalis.Specification;

namespace Benivo.Jobs.Core.JobAggregate.Specifications
{
    public abstract class BaseFilteredJobsSpecification : Specification<Job>
    {
        protected BaseFilteredJobsSpecification(
            string? title = null,
            IEnumerable<int>? categoryIds = null,
            IEnumerable<int>? employmentTypeIds = null,
            IEnumerable<int>? locationIds = null,
            IEnumerable<int>? companyIds = null)
        {
            if (!string.IsNullOrWhiteSpace(title))
                Query.Where(j => j.Title.Contains(title));

            if (companyIds?.Any() ?? false)
                Query.Where(j => companyIds.Contains(j.Company.Id));

            if (categoryIds?.Any() ?? false)
                Query.Where(j => categoryIds.Contains(j.Category.Id));

            if (locationIds?.Any() ?? false)
                Query.Where(j => locationIds.Contains(j.JobLocation.Id));

            if (employmentTypeIds?.Any() ?? false)
                Query.Where(j => employmentTypeIds.Contains(j.EmploymentType.Id));
        }
    }
}
