using System;
using System.Collections.Generic;
using System.Linq;
using Ardalis.Specification;

namespace Benivo.Jobs.Core.JobAggregate.Specifications
{
    public sealed class PaginatedFilteredJobSpecifcation : Specification<Job>
    {
        public PaginatedFilteredJobSpecifcation(
            string? title,
            IEnumerable<int>? categoryIds,
            IEnumerable<int>? employmentTypeIds,
            IEnumerable<int>? locationIds,
            (int PageSize, int PageNumber)? page)
        {
            Query
                .AsNoTracking()
                .Include(j => j.Bookmark)
                .Include(j => j.JobLocation)
                .Include(j => j.EmploymentType);

            if (!string.IsNullOrWhiteSpace(title))
                Query.Where(j => j.Title.Contains(title));

            if (categoryIds?.Any() ?? false)
                Query.Where(j => categoryIds.Contains(j.Category.Id));

            if (locationIds?.Any() ?? false)
                Query.Where(j => locationIds.Contains(j.JobLocation.Id));

            if (employmentTypeIds?.Any() ?? false)
                Query.Where(j => employmentTypeIds.Contains(j.EmploymentType.Id));

            if (page is not null)
            {
                var (pageSize, pageNumber) = page.Value;
                Query
                    // 1 based index indexing
                    .Skip(pageSize * (pageNumber - 1))
                    .Take(pageNumber);
            }
        }
    }
}
