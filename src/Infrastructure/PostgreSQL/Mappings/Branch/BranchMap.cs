using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Infrastructure.PostgreSQL.Shared.Mappings;

namespace Infrastructure.PostgreSQL.Mappings.Branch
{
    public class BranchMap : EntityMap<Domain.Branch.Models.Branch>
    {
        protected override void ConfigureMap(EntityTypeBuilder<Domain.Branch.Models.Branch> builder)
        {
            builder.Property(x => x.Name);
        }
    }
}