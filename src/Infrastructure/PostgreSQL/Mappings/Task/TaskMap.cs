using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Infrastructure.PostgreSQL.Shared.Mappings;

namespace Infrastructure.PostgreSQL.Mappings.Task
{
    public class TaskMap : EntityMap<Domain.Task.Models.Task>
    {
        protected override void ConfigureMap(EntityTypeBuilder<Domain.Task.Models.Task> builder)
        {
            builder.Property(x => x.Name);
            builder.Property(x => x.Description);
            builder.Property(x => x.Estimation);
            builder.Property(x => x.Priority);
            builder.Property(x => x.Criticality);
            builder.Property(x => x.DeliveryDate);
        }
    }
}