using Benivo.Jobs.Core.CompanyAggregate;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Benivo.Jobs.Infrastructure.Data.Config
{
    public sealed class CompanyConfiguration : BaseConfiguration<Company>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Company> builder)
        {
            // Much better performance than nvarchar(max) which is the ef-core default
            builder.Property(c => c.Title)
                .HasMaxLength(500);

            // Should not use sql-server image type as it will be retired
        }
    }
}
