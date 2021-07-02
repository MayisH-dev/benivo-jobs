using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Benivo.Jobs.Web.Endpoints.JobEndpoints.List
{
    public sealed class List :
        BaseAsyncEndpoint
            .WithRequest<ListRequest>
            .WithResponse<ListResponse>
    {
        [HttpGet("/jobs")]
        [SwaggerOperation(
            Summary = "Gets a list of job posts",
            Description = "Gets a list of all job posts (if no query is specified), or filtered job posts",
            OperationId = "Jobs.List",
            Tags = new[] { "JobEndpoints" })
        ]

        public override Task<ActionResult<ListResponse>> HandleAsync([FromQuery] ListRequest request, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }
    }
}
