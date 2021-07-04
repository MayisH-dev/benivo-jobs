using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using Benivo.Jobs.Core.JobAggregate;
using Benivo.Jobs.Core.JobAggregate.Specifications;
using Benivo.Jobs.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Benivo.Jobs.Web.Endpoints.JobEndpoints.List
{
    public sealed class List :
        BaseAsyncEndpoint
            .WithRequest<ListRequest>
            .WithResponse<ListResponse>
    {
        private readonly IReadRepository<Job> _repository;

        public List(IReadRepository<Job> repository)
        {
            _repository = repository;
        }

        [HttpGet("/jobs")]
        [SwaggerOperation(
            Summary = "Gets a list of job posts",
            Description = "Gets a list of all job posts (if no query is specified), or filtered job posts",
            OperationId = "Jobs.List",
            Tags = new[] { "JobEndpoints" })
        ]

        public override async Task<ActionResult<ListResponse>> HandleAsync([FromQuery] ListRequest request, CancellationToken cancellationToken = default)
        {
            (int PageSize, int PageNumber)? pagination = request.Page is null
                ? null
                : (request.Page.Size, request.Page.Number);

            PaginatedFilteredJobSpecifcation spec = new(
                request.Title,
                request.CategoryIds,
                request.EmploymentTypeIds,
                request.LocationIds,
                pagination
            );

            return Ok(await _repository.ListAsync(spec, cancellationToken));
        }
    }
}
