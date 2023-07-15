using Domain.Shared.Entities;

namespace Domain.Scenario.Models
{
    public class Scenario : Entity
    {
        public int Name { get; private set; }
        public int Description { get; private set; }
        public int Criticality { get; private set; }

        public Scenario(
            int name,
            int description,
            int criticality
        )
        {
            this.Name = name;
            this.Description = description;
            this.Criticality = criticality;
        }
        public void Update(
            int name,
            int description,
            int criticality
        )
        {
            this.Name = name;
            this.Description = description;
            this.Criticality = criticality;
        }
    }
}