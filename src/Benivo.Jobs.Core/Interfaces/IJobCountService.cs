using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.Specification;
using Benivo.Jobs.Core.CompanyAggregate;

namespace Benivo.Jobs.Core.JobAggregate.Interfaces
{
    public interface IJobCountService
    {
        Task<IEnumerable<(Category Category, int Count)>> CountJobsByCategory(
            ISpecification<Job> specification,
            CancellationToken? cancellationToken = null);

        Task<IEnumerable<(Company Company, int Count)>> CountJobsByCompany(
            ISpecification<Job> specification,
            CancellationToken? cancellationToken = null);

        Task<IEnumerable<(EmploymentType EmploymentType, int Count)>> CountJobsByEmploymentType(
            ISpecification<Job> specification,
            CancellationToken? cancellationToken = null);

        Task<IEnumerable<(JobLocation JobLocation, int Count)>> CountJobsByJobLocation(
            ISpecification<Job> specification,
            CancellationToken? cancellationToken = null);
    }
}