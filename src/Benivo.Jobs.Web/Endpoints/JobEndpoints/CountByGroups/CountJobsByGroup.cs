using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using Benivo.Jobs.Core.JobAggregate.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Benivo.Jobs.Web.Endpoints.JobEndpoints.CountByGroups
{
    public sealed class CountJobsByGroups :
        BaseAsyncEndpoint
            .WithRequest<CountJobsByGroupsRequest>
            .WithResponse<CountJobsByGroupsResponse>
    {
        private readonly IJobCountService _jobCountService;

        public CountJobsByGroups(IJobCountService jobCountService) =>
            _jobCountService = jobCountService;

        [HttpGet("/jobs/count-by-groups")]
        [SwaggerOperation(
            Summary = "Gets the number of jobs grouped by their attributes",
            Description = "Gets the number of jobs grouped by their attributes satsfying the given filter",
            OperationId = "Jobs.CountJobsByGroups",
            Tags = new[] { "JobEndpoints" })
        ]
        public override async Task<ActionResult<CountJobsByGroupsResponse>> HandleAsync(
            [FromQuery] CountJobsByGroupsRequest request,
            CancellationToken cancellationToken = default)
        {
            var spec = request.ToFilteredJobsSpecification();

            var countByCategory = await _jobCountService.CountJobsByCategory(spec, cancellationToken);
            var countByEmploymentType = await _jobCountService.CountJobsByEmploymentType(spec, cancellationToken);
            var countyByLocation = await _jobCountService.CountJobsByJobLocation(spec, cancellationToken);
            var countByCompany = await _jobCountService.CountJobsByCompany(spec, cancellationToken);

            CountJobsByGroupsResponse response = new(countByCategory, countByEmploymentType, countyByLocation, countByCompany);

            return Ok(response);
        }


    }
}
