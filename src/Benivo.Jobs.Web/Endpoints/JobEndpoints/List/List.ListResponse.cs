using System.Collections.Generic;

namespace Benivo.Jobs.Web.Endpoints.JobEndpoints.List
{
    public sealed record EmploymentTypeResponse(int Id, string Title);

    public sealed record JobLocationResponse(int Id, string Location);

    public sealed record JobResponse(
        int Id,
        string Title,
        bool IsBookmarked,
        JobLocationResponse Location,
        EmploymentTypeResponse EmploymentType
    );

    public sealed record ListResponse(IEnumerable<JobResponse> Jobs);
}