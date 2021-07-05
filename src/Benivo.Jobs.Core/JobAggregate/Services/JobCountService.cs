using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.Specification;
using Benivo.Jobs.Core.CompanyAggregate;
using Benivo.Jobs.Core.JobAggregate.Interfaces;
using Benivo.Jobs.SharedKernel.Interfaces;

namespace Benivo.Jobs.Core.JobAggregate.Services
{
    public sealed class JobCountService : IJobCountService
    {
        private readonly IAggregatingReadRepository<Job> _repsitory;

        public JobCountService(IAggregatingReadRepository<Job> repository)
        {
            _repsitory = repository;
        }

        public async Task<IEnumerable<(Category Category, int Count)>> CountJobsByCategory(
            ISpecification<Job> specification,
            CancellationToken? cancellationToken = null)
        {
            var results = await _repsitory.CountByNonZeroAsync(
                j => new { j.Category.Id, j.Category.Title },
                specification,
                cancellationToken);

            return results.Select(j =>
                (new Category(j.Key.Title) { Id = j.Key.Id },
                j.Count));
        }

        public async Task<IEnumerable<(EmploymentType EmploymentType, int Count)>> CountJobsByEmploymentType(
            ISpecification<Job> specification,
            CancellationToken? cancellationToken = null)
        {
            var results = await _repsitory.CountByNonZeroAsync(
                j => new { j.EmploymentType.Id, j.EmploymentType.Title },
                specification,
                cancellationToken);

            return results.Select(j =>
                (new EmploymentType(j.Key.Title) { Id = j.Key.Id },
                j.Count));
        }

        public async Task<IEnumerable<(JobLocation JobLocation, int Count)>> CountJobsByJobLocation(
            ISpecification<Job> specification,
            CancellationToken? cancellationToken = null)
        {
            var results = await _repsitory.CountByNonZeroAsync(
                j => new { j.JobLocation.Id, j.JobLocation.Location },
                specification,
                cancellationToken);

            return results.Select(j =>
                (new JobLocation(j.Key.Location) { Id = j.Key.Id },
                j.Count));
        }

        public async Task<IEnumerable<(Company Company, int Count)>> CountJobsByCompany(
            ISpecification<Job> specification,
            CancellationToken? cancellationToken = null)
        {
            var results = await _repsitory.CountByNonZeroAsync(
                j => new { j.Company.Id, j.Company.Title },
                specification,
                cancellationToken);

            return results.Select(j =>
                (new Company(j.Key.Title, Array.Empty<byte>()) { Id = j.Key.Id },
                j.Count));
        }
    }
}
