using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.EFCore.Extensions;
using Benivo.Jobs.Core.ProjectAggregate;
using Benivo.Jobs.SharedKernel;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Benivo.Jobs.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        private readonly IMediator _mediator;

        public AppDbContext(DbContextOptions<AppDbContext> options, IMediator mediator)
            : base(options)
        {
            _mediator = mediator;
        }

        public DbSet<ToDoItem> ToDoItems { get; set; }
        public DbSet<Project> Projects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyAllConfigurationsFromCurrentAssembly();
        }

        /// <returns>Number of entries written to the database</returns>
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            int result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            // ignore events if no dispatcher provided
            if (_mediator == null) return result;

            // dispatch events only if save was successful
            var entitiesWithEvents = ChangeTracker.Entries<BaseEntity>()
                .Select(e => e.Entity)
                .Where(e => e.Events.Any())
                .ToArray();

            foreach (var entity in entitiesWithEvents)
            {
                var events = entity.Events.ToArray();
                entity.ClearDomainEvents();
                foreach (var domainEvent in events)
                {
                    await _mediator.Publish(domainEvent, cancellationToken).ConfigureAwait(false);
                }
            }

            return result;
        }

        /// <remarks>Should not be used in production, use the asynchronous version instead</remarks>
        /// <returns>Number of entries written to the database</returns>
        public override int SaveChanges() => SaveChangesAsync().GetAwaiter().GetResult();
    }
}