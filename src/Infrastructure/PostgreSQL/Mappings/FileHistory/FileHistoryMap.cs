using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Infrastructure.PostgreSQL.Shared.Mappings;

namespace Infrastructure.PostgreSQL.Mappings.FileHistory
{
    public class FileHistoryMap : EntityMap<Domain.FileHistory.Models.FileHistory>
    {
        protected override void ConfigureMap(EntityTypeBuilder<Domain.FileHistory.Models.FileHistory> builder)
        {
            builder.Property(x => x.LinesAdded);
            builder.Property(x => x.LinesRemoved);
            builder.Property(x => x.Operation);
        }
    }
}