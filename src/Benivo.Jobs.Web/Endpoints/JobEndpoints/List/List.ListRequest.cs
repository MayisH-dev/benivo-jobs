using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Benivo.Jobs.Web.Endpoints.JobEndpoints.List
{
    public sealed record PageRequest(
        [Required, Range(1, int.MaxValue)]
        int Number,
        [Required, Range(10, int.MaxValue)]
        int Size
    );

    public sealed record ListRequest(
        PageRequest? Page,
        string? Title,
        IEnumerable<int>? CategoryIds,
        IEnumerable<int>? EmploymentTypeIds,
        IEnumerable<int>? LocationIds
    );
}
