using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using Benivo.Jobs.Core.JobAggregate;
using Benivo.Jobs.Core.JobAggregate.Specifications;
using Benivo.Jobs.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Benivo.Jobs.Web.Endpoints.JobEndpoints.GetById
{
    public sealed class GetById :
        BaseAsyncEndpoint
            .WithRequest<GetJobByIdRequest>
            .WithResponse<GetJobByIdResponse>
    {
        private readonly IReadRepository<Job> _repository;

        public GetById(IReadRepository<Job> repository)
        {
            _repository = repository;
        }

        [HttpGet("/jobs/{id:int}")]
        [SwaggerOperation(
            Summary = "Gets a job post",
            Description = "Gets the details of a job post",
            OperationId = "Jobs.GetById",
            Tags = new[] { "JobEndpoints" })
        ]
        public override async Task<ActionResult<GetJobByIdResponse>> HandleAsync([FromRoute] GetJobByIdRequest request, CancellationToken cancellationToken = default)
        {
            var spec = new JobDetailsByIdSpecification(request.Id);

            var result = await _repository.GetBySpecAsync(spec, cancellationToken);

            return result is null
                ? NotFound()
                : Ok(new GetJobByIdResponse(result));
        }
    }
}
