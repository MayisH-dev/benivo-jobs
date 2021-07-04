using Benivo.Jobs.Core.JobAggregate;

namespace Benivo.Jobs.Web.Endpoints.JobEndpoints.GetById
{
    public sealed record GetJobByIdResponse(
        int Id,
        string Title,
        string Description,
        bool IsBookmarked,
        int CompanyId,
        string CompanyTitle,
        int CategoryId,
        string CategoryTitle,
        int LocationId,
        string Location,
        int EmploymentTypeId,
        string EmploymentTypeTitle)
    {
        // Can use a object to object mapping library (e.g. AutoMapper, Mapster) to make code like this less verbose
        internal GetJobByIdResponse(Job job)
            : this(
                job.Id,
                job.Title,
                job.Description,
                job.IsBookmarked,
                job.Company.Id,
                job.Company.Title,
                job.Category.Id,
                job.Category.Title,
                job.JobLocation.Id,
                job.JobLocation.Location,
                job.EmploymentType.Id,
                job.EmploymentType.Title
            )
        { }
    }
}