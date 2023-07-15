using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Infrastructure.PostgreSQL.Shared.Mappings;

namespace Infrastructure.PostgreSQL.Mappings.Developer
{
    public class DeveloperMap : EntityMap<Domain.Developer.Models.Developer>
    {
        protected override void ConfigureMap(EntityTypeBuilder<Domain.Developer.Models.Developer> builder)
        {
            builder.Property(x => x.Name);
            builder.Property(x => x.WorkingHours);
            builder.Property(x => x.Experience);
            builder.Property(x => x.Code);
            builder.HasMany(x => x.Commits).WithOne(x => x.Developer).HasForeignKey(x => x.DeveloperId);
        }
    }
}