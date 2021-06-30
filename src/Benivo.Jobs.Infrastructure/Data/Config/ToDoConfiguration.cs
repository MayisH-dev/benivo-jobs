using Benivo.Jobs.Core.ProjectAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Benivo.Jobs.Infrastructure.Data.Config
{
    public class ToDoConfiguration : IEntityTypeConfiguration<ToDoItem>
    {
        public void Configure(EntityTypeBuilder<ToDoItem> builder)
        {
            builder.Property(t => t.Title)
                .IsRequired();
        }
    }
}
