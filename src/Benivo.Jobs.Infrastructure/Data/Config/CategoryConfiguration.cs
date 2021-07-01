using Benivo.Jobs.Core.JobAggregate;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Benivo.Jobs.Infrastructure.Data.Config
{
    public sealed class CategoryConfiguration : BaseConfiguration<Category>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Category> builder)
        {
            // Much better performance than nvarchar(max) which is the ef-core default
            builder.Property(c => c.Title)
                .HasMaxLength(500);
        }
    }
}
