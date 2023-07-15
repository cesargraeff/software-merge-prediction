using Domain.Shared.Entities;

namespace Domain.Functionality.Models
{
    public class Functionality : Entity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        public Functionality(
            string name,
            string description
        )
        {
            this.Name = name;
            this.Description = description;
        }
        public void Update(
            string name,
            string description
        )
        {
            this.Name = name;
            this.Description = description;
        }
    }
}