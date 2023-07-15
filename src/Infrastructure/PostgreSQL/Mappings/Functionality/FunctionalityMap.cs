using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Infrastructure.PostgreSQL.Shared.Mappings;

namespace Infrastructure.PostgreSQL.Mappings.Functionality
{
    public class FunctionalityMap : EntityMap<Domain.Functionality.Models.Functionality>
    {
        protected override void ConfigureMap(EntityTypeBuilder<Domain.Functionality.Models.Functionality> builder)
        {
            builder.Property(x => x.Name);
            builder.Property(x => x.Description);
        }
    }
}