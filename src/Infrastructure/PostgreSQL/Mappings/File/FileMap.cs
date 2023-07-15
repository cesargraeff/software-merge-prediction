using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Infrastructure.PostgreSQL.Shared.Mappings;

namespace Infrastructure.PostgreSQL.Mappings.File
{
    public class FileMap : EntityMap<Domain.File.Models.File>
    {
        protected override void ConfigureMap(EntityTypeBuilder<Domain.File.Models.File> builder)
        {
            builder.Property(x => x.Name);
            builder.Property(x => x.Path);
        }
    }
}