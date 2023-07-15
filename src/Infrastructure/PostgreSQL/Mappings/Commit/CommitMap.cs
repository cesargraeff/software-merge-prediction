using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Infrastructure.PostgreSQL.Shared.Mappings;

namespace Infrastructure.PostgreSQL.Mappings.Commit
{
    public class CommitMap : EntityMap<Domain.Commit.Models.Commit>
    {
        protected override void ConfigureMap(EntityTypeBuilder<Domain.Commit.Models.Commit> builder)
        {
            builder.Property(x => x.Code);
            builder.Property(x => x.Description);
            builder.Property(x => x.Date);
            builder.Property(x => x.Conflict);
            builder.HasOne(x => x.Developer).WithMany(x => x.Commits).HasForeignKey(x => x.DeveloperId);
        }
    }
}