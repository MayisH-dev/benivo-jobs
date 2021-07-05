using System.Collections.Generic;
using Benivo.Jobs.Core.JobAggregate;

namespace Benivo.Jobs.Web.Endpoints.JobEndpoints.List
{

    public sealed record JobResponse(
        int Id,
        string Title,
        bool IsBookmarked,
        int LocationId,
        string Location,
        int EmploymentTypeId,
        string EmploymentTypeTitle)
    {
        // Can use a object to object mapping library (e.g. AutoMapper, Mapster) to make code like this less verbose
        internal JobResponse(Job job)
            : this(
                job.Id,
                job.Title,
                job.IsBookmarked,
                job.JobLocation.Id,
                job.JobLocation.Location,
                job.EmploymentType.Id,
                job.EmploymentType.Title
            )
        { }
    }

    public sealed record ListJobsResponse(IEnumerable<JobResponse> Jobs);
}