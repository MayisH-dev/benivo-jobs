using Benivo.Jobs.Core.CompanyAggregate;
using Benivo.Jobs.Core.JobAggregate;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Benivo.Jobs.Infrastructure.Data.Config
{
    public sealed class JobConfiguration : BaseConfiguration<Job>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Job> builder)
        {
            // Much better performance than nvarchar(max) which is the ef-core default
            builder.Property(j => j.Title)
                .HasMaxLength(500);

            // These have to be explicitly specified, as by convention ef-core treats shadow fk backed navigation properties as nullable
            // (even with c# nullable context enabled at the project level)
            builder.HasOne<Category>(j => j.Category)
                .WithMany();

            builder.HasOne<JobLocation>(j => j.JobLocation)
                .WithMany();

            builder.HasOne<Company>(j => j.Company)
                .WithMany();

            builder.HasOne<EmploymentType>(j => j.EmploymentType)
                .WithMany();

            builder.HasOne<JobLocation>(j => j.JobLocation)
                .WithMany();
        }
    }
}
