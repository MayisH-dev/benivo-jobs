using Benivo.Jobs.Core.JobAggregate;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Benivo.Jobs.Infrastructure.Data.Config
{
    public sealed class BookmarkConfiguration : BaseConfiguration<Bookmark>
    {
        private static readonly string JobForeignKeyColumn = nameof(Job) + "Id";
        protected override void ConfigureEntity(EntityTypeBuilder<Bookmark> builder)
        {
            // See more: EF Core shadow properties
            builder.HasAlternateKey(JobForeignKeyColumn);

            builder.HasOne(b => b.Job)
                .WithOne(j => j!.Bookmark!)
                .HasForeignKey<Bookmark>(JobForeignKeyColumn);
        }
    }
}
