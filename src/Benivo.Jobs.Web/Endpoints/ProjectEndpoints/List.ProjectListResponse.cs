using System.Collections.Generic;
using Benivo.Jobs.Core.ProjectAggregate;

namespace Benivo.Jobs.Web.Endpoints.ProjectEndpoints
{
    public class ProjectListResponse
    {
        public List<ProjectRecord> Projects { get; set; } = new();
    }
}
