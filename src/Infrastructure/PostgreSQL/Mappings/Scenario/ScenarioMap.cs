using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Infrastructure.PostgreSQL.Shared.Mappings;

namespace Infrastructure.PostgreSQL.Mappings.Scenario
{
    public class ScenarioMap : EntityMap<Domain.Scenario.Models.Scenario>
    {
        protected override void ConfigureMap(EntityTypeBuilder<Domain.Scenario.Models.Scenario> builder)
        {
            builder.Property(x => x.Name);
            builder.Property(x => x.Description);
            builder.Property(x => x.Criticality);
        }
    }
}