using System.Collections.Generic;
using Benivo.Jobs.Core.JobAggregate;

namespace Benivo.Jobs.Web.Endpoints.JobEndpoints.List
{
    public sealed record EmploymentTypeResponse(int Id, string Title);

    public sealed record JobLocationResponse(int Id, string Location);

    public sealed record JobResponse(
        int Id,
        string Title,
        bool IsBookmarked,
        JobLocationResponse Location,
        EmploymentTypeResponse EmploymentType)
    {
        // Can use a object to object mapping library (e.g. AutoMapper, Mapster) to make code like this less verbose
        internal JobResponse(Job job)
            : this(
                job.Id,
                job.Title,
                job.IsBookmarked,
                new(
                    job.JobLocation.Id,
                    job.JobLocation.Location
                ),
                new(
                    job.EmploymentType.Id,
                    job.EmploymentType.Title
                )
            )
        { }
    }

    public sealed record ListResponse(IEnumerable<JobResponse> Jobs);
}