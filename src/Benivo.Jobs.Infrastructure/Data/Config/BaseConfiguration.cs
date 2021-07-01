using Benivo.Jobs.SharedKernel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Benivo.Jobs.Infrastructure.Data.Config
{
    /// <summary>
    /// Configuration that is common for all entity types
    /// </summary>
    /// <typeparam name="TEntity">The type of entity</typeparam>
    public abstract class BaseConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
    {
        public void Configure(EntityTypeBuilder<TEntity> builder)
        {
            ConfigureCommon(builder);
            ConfigureEntity(builder);
        }

        /// <summary>
        /// Used for specifying configuration settings common for all entity types
        /// </summary>
        /// <param name="builder"></param>
        private static void ConfigureCommon(EntityTypeBuilder<TEntity> builder)
        {
            // Ignore domain events' property explicitly, as by ef core convention they are treated as entities
            builder.Ignore(e => e.Events);
        }

        /// <summary>
        /// Template method that is used to provide entity specific conifiguration
        /// </summary>
        /// <param name="builder"></param>
        protected virtual void ConfigureEntity(EntityTypeBuilder<TEntity> builder) { }
    }
}
