using System.Collections.Generic;
using System.Linq;
using Ardalis.Specification;

namespace Benivo.Jobs.Core.JobAggregate.Specifications
{
    public sealed class PaginatedFilteredJobsSpecification : BaseFilteredJobsSpecification
    {
        public PaginatedFilteredJobsSpecification(
            string? title = null,
            IEnumerable<int>? categoryIds = null,
            IEnumerable<int>? employmentTypeIds = null,
            IEnumerable<int>? locationIds = null,
            (int PageSize, int PageNumber)? page = null)
            : base(title, categoryIds, employmentTypeIds, locationIds)
        {
            Query
                .AsNoTracking()
                .Include(j => j.Bookmark)
                .Include(j => j.JobLocation)
                .Include(j => j.EmploymentType);

            if (page is not null)
            {
                var (pageSize, pageNumber) = page.Value;
                Query
                    // 1 based page indexing
                    .Skip(pageSize * (pageNumber - 1))
                    .Take(pageSize);
            }
        }
    }
}
