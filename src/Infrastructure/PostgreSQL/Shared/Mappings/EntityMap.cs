using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Domain.Shared.Entities;

namespace Infrastructure.PostgreSQL.Shared.Mappings
{
    public abstract class EntityMap<T> : IEntityTypeConfiguration<T> where T : Entity
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CreatedAt).IsRequired().HasColumnType("timestamp with time zone");
            builder.Property(x => x.UpdatedAt).IsRequired().HasColumnType("timestamp with time zone");

            ConfigureMap(builder);
        }

        protected abstract void ConfigureMap(EntityTypeBuilder<T> builder);
    }
}