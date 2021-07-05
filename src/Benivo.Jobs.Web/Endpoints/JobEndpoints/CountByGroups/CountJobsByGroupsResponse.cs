using System.Collections.Generic;
using System.Linq;
using Benivo.Jobs.Core.CompanyAggregate;
using Benivo.Jobs.Core.JobAggregate;

namespace Benivo.Jobs.Web.Endpoints.JobEndpoints.CountByGroups
{
    public sealed record CountJobsByGroupReponse(int Id, string Title, int Count)
    {
        internal CountJobsByGroupReponse((Category Category, int Count) countPair)
         : this(countPair.Category.Id, countPair.Category.Title, countPair.Count) { }

        internal CountJobsByGroupReponse((Company Company, int Count) countPair)
        : this(countPair.Company.Id, countPair.Company.Title, countPair.Count) { }

        internal CountJobsByGroupReponse((JobLocation JobLocation, int Count) countPair)
        : this(countPair.JobLocation.Id, countPair.JobLocation.Location, countPair.Count) { }

        internal CountJobsByGroupReponse((EmploymentType EmploymentType, int Count) countPair)
        : this(countPair.EmploymentType.Id, countPair.EmploymentType.Title, countPair.Count) { }
    }

    public sealed record CountJobsByGroupsResponse(
        IEnumerable<CountJobsByGroupReponse> Categories,
        IEnumerable<CountJobsByGroupReponse> Locations,
        IEnumerable<CountJobsByGroupReponse> EmploymentTypes,
        IEnumerable<CountJobsByGroupReponse> Companies
    )
    {
        internal CountJobsByGroupsResponse(
            IEnumerable<(Category key, int Count)> countByCategory,
            IEnumerable<(EmploymentType key, int Count)> countByEmploymentType,
            IEnumerable<(JobLocation key, int Count)> countyByLocation,
            IEnumerable<(Company key, int Count)> countByCompany)
            : this(countByCategory.Select(c => new CountJobsByGroupReponse(c)),
                countyByLocation.Select(c => new CountJobsByGroupReponse(c)),
                countByEmploymentType.Select(c => new CountJobsByGroupReponse(c)),
                countByCompany.Select(c => new CountJobsByGroupReponse(c)))
        {
        }
    }
}