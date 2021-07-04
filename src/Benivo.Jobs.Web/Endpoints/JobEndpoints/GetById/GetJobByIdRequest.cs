using Microsoft.AspNetCore.Mvc;

namespace Benivo.Jobs.Web.Endpoints.JobEndpoints.GetById
{
    public sealed record GetJobByIdRequest([FromRoute] int Id);
}