using Benivo.Jobs.Core.ProjectAggregate;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Benivo.Jobs.Infrastructure.Data.Config
{
    public sealed class ToDoConfiguration : BaseConfiguration<ToDoItem>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<ToDoItem> builder)
        {
            builder.Property(t => t.Title)
                .IsRequired();
        }
    }
}
