using System.Linq;
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
            .WithRequest<ListJobsRequest>
            .WithResponse<ListJobsResponse>
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

        public override async Task<ActionResult<ListJobsResponse>> HandleAsync(
            [FromQuery] ListJobsRequest request,
            CancellationToken cancellationToken = default)
        {
            var spec = request.ToPaginatedFilteredJobsSpecification();


            var results = await _repository.ListAsync(spec, cancellationToken);

            var jobs = from job in results select new JobResponse(job);

            ListJobsResponse response = new(jobs);

            return Ok(response);
        }
    }
}
