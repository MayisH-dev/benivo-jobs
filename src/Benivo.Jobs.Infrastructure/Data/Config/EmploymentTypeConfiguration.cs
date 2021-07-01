using Benivo.Jobs.Core.JobAggregate;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Benivo.Jobs.Infrastructure.Data.Config
{
    public sealed class EmploymentTypeConfiguration : BaseConfiguration<EmploymentType>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<EmploymentType> builder)
        {
            // Much better performance than nvarchar(max) which is the ef-core default
            builder.Property(e => e.Title)
                .HasMaxLength(500);
        }
    }
}
