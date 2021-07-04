using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using Benivo.Jobs.Core.JobAggregate;
using Benivo.Jobs.Core.JobAggregate.Specifications;
using Benivo.Jobs.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Benivo.Jobs.Web.Endpoints.JobEndpoints.RemoveBookmark
{
    public sealed class RemoveJobBookmark :
        BaseAsyncEndpoint
            .WithRequest<RemoveJobBookmarkRequest>
            .WithoutResponse
    {
        private readonly IRepository<Job> _repository;

        public RemoveJobBookmark(IRepository<Job> repository)
        {
            _repository = repository;
        }

        [HttpPatch("/jobs/{Id:int}/remove-bookmark")]
        [SwaggerOperation(
            Summary = "Removes a bookmark from a job",
            Description = "Removes the bookmark from the job with the given id",
            OperationId = "Jobs.AddBookmark",
            Tags = new[] { "JobEndpoints" })
        ]
        public override async Task<ActionResult> HandleAsync(
            [FromRoute] RemoveJobBookmarkRequest request,
            CancellationToken cancellationToken = default)
        {
            var spec = new JobBookmarkByIdSpecification(request.Id);

            var job = await _repository.GetBySpecAsync(spec, cancellationToken);

            if (job is null)
                return NotFound("Job not found");
            else if (job.Bookmark is null)
                return Conflict("Bookmark does not exist");
            else
            {
                job.RemoveBookmark();
                await _repository.UpdateAsync(job, cancellationToken);
                return Ok();
            }
        }
    }
}
