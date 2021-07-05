using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Benivo.Jobs.Core.JobAggregate.Specifications;

namespace Benivo.Jobs.Web.Endpoints.JobEndpoints.List
{
    public sealed record Page(
        [Required, Range(1, int.MaxValue)]
        int Number,
        [Required, Range(10, int.MaxValue)]
        int Size
    );

    public sealed record ListJobsRequest(
        Page Page,
        string? Title,
        IEnumerable<int>? CategoryIds,
        IEnumerable<int>? EmploymentTypeIds,
        IEnumerable<int>? LocationIds
    )
    {
        internal PaginatedFilteredJobsSpecification ToPaginatedFilteredJobsSpecification()
        {

            (int PageSize, int PageNumber)? pagination = Page is null
                ? null
                : (Page.Size, Page.Number);

            return new(
                Title,
                CategoryIds,
                EmploymentTypeIds,
                LocationIds,
                pagination
            );
        }
    }
}
