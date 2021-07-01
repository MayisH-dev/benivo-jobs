using Benivo.Jobs.Core.JobAggregate;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Benivo.Jobs.Infrastructure.Data.Config
{
    public sealed class JobLocationConfiguration : BaseConfiguration<JobLocation>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<JobLocation> builder)
        {
            // Much better performance than nvarchar(max) which is the ef-core default
            builder.Property(j => j.Location)
                .HasMaxLength(500);
        }
    }
}
