using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Infrastructure.PostgreSQL.Shared.Mappings;

namespace Infrastructure.PostgreSQL.Mappings.Class
{
    public class ClassMap : EntityMap<Domain.Class.Models.Class>
    {
        protected override void ConfigureMap(EntityTypeBuilder<Domain.Class.Models.Class> builder)
        {
            builder.Property(x => x.Name);
            builder.Property(x => x.StartLine);
            builder.Property(x => x.FinishLine);
        }
    }
}