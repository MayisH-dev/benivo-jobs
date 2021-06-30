using Benivo.Jobs.Core.ProjectAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Benivo.Jobs.Infrastructure.Data.Config
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.Property(p => p.Name)
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
