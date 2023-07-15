using Domain.Shared.Entities;

namespace Domain.Branch.Models
{
    public class Branch : Entity
    {
        public string Name { get; private set; }

        public Branch(
            string name
        )
        {
            this.Name = name;
        }
        public void Update(
            string name
        )
        {
            this.Name = name;
        }
    }
}
