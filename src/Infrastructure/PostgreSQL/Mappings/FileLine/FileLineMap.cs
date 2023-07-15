using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Infrastructure.PostgreSQL.Shared.Mappings;

namespace Infrastructure.PostgreSQL.Mappings.FileLine
{
    public class FileLineMap : EntityMap<Domain.FileLine.Models.FileLine>
    {
        protected override void ConfigureMap(EntityTypeBuilder<Domain.FileLine.Models.FileLine> builder)
        {
            builder.Property(x => x.Line);
            builder.Property(x => x.Code);
            builder.Property(x => x.Operation);
        }
    }
}