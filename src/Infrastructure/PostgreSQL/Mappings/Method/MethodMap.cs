using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Infrastructure.PostgreSQL.Shared.Mappings;

namespace Infrastructure.PostgreSQL.Mappings.Method
{
    public class MethodMap : EntityMap<Domain.Method.Models.Method>
    {
        protected override void ConfigureMap(EntityTypeBuilder<Domain.Method.Models.Method> builder)
        {
            builder.Property(x => x.Name);
            builder.Property(x => x.StartLine);
            builder.Property(x => x.FinishLine);
        }
    }
}