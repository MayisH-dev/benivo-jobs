using Ardalis.Specification.EntityFrameworkCore;
using Benivo.Jobs.SharedKernel.Interfaces;

namespace Benivo.Jobs.Infrastructure.Data
{
    public class EfRepository<T> : RepositoryBase<T>, IReadRepository<T>, IRepository<T> where T : class, IAggregateRoot
    {
        public EfRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
