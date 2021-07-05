using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using Benivo.Jobs.Core.JobAggregate;
using Benivo.Jobs.Core.JobAggregate.Specifications;
using Benivo.Jobs.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Benivo.Jobs.Web.Endpoints.JobEndpoints.AddBookmark
{
    public sealed class AddJobBookmark :
        BaseAsyncEndpoint
            .WithRequest<AddJobBookmarkRequest>
            .WithoutResponse
    {
        private readonly IRepository<Job> _repository;

        public AddJobBookmark(IRepository<Job> repository)
        {
            _repository = repository;
        }

        [HttpPatch("/jobs/{Id:int}/add-bookmark")]
        [SwaggerOperation(
            Summary = "Bookmarks a job",
            Description = "Bookmarks the job with the given id",
            OperationId = "Jobs.AddBookmark",
            Tags = new[] { "JobEndpoints" })
        ]
        public override async Task<ActionResult> HandleAsync(
            [FromRoute] AddJobBookmarkRequest request,
            CancellationToken cancellationToken = default)
        {
            var spec = new JobBookmarkByIdSpecification(request.Id);

            var job = await _repository.GetBySpecAsync(spec, cancellationToken);

            if (job is null)
                return NotFound("Job not found");
            else if (job.Bookmark is not null)
                return Conflict("Bookmark already exists");
            else
            {
                job.AddBookmark(new());
                await _repository.UpdateAsync(job, cancellationToken);
                return Ok();
            }
        }
    }
}
