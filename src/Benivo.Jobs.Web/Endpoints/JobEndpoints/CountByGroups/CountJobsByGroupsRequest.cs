using System.Collections.Generic;
using Benivo.Jobs.Core.JobAggregate.Specifications;

namespace Benivo.Jobs.Web.Endpoints.JobEndpoints.CountByGroups
{
    public sealed record CountJobsByGroupsRequest(
        string? Title,
        IEnumerable<int>? CategoryIds,
        IEnumerable<int>? EmploymentTypeIds,
        IEnumerable<int>? LocationIds)
    {
        internal FilteredJobsSpecification ToFilteredJobsSpecification()
        {
            return new(
                Title,
                CategoryIds,
                EmploymentTypeIds,
                LocationIds
            );
        }
    }
}