using System.Collections.Generic;

namespace Benivo.Jobs.Core.JobAggregate.Specifications
{
    public sealed class FilteredJobsSpecification : BaseFilteredJobsSpecification
    {
        public FilteredJobsSpecification(
            string? title = null,
            IEnumerable<int>? categoryIds = null,
            IEnumerable<int>? employmentTypeIds = null,
            IEnumerable<int>? locationIds = null)
            : base(title, categoryIds, employmentTypeIds, locationIds)
        {
        }
    }
}
