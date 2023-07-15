using System.Text.Json.Serialization;
using Domain.Shared.Entities;

namespace Domain.Developer.Models
{
    public class Developer : Entity
    {
        public string Name { get; private set; }
        public int WorkingHours { get; private set; }
        public int Experience { get; private set; }
        public int Code { get; private set; }

        [JsonIgnore]
        public virtual IEnumerable<Domain.Commit.Models.Commit>? Commits { get; private set; }

        public Developer(
            string name,
            int workingHours,
            int experience,
            int code = 0
        )
        {
            this.Name = name;
            this.WorkingHours = workingHours;
            this.Experience = experience;
            this.Code = code;
        }
        public void Update(
            string name,
            int workingHours,
            int experience
        )
        {
            this.Name = name;
            this.WorkingHours = workingHours;
            this.Experience = experience;
        }
    }
}