using Domain.Shared.Entities;

namespace Domain.Commit.Models
{
    public class Commit : Entity
    {
        public string Code { get; private set; }
        public string Description { get; private set; }
        public DateTime Date { get; private set; }
        public bool Conflict { get; private set; }

        public Domain.Developer.Models.Developer? Developer { get; private set; }
        public Guid? DeveloperId { get; private set; }

        public Commit(
            string code,
            string description,
            DateTime date,
            bool conflict,
            Guid? developerId = null
        )
        {
            this.Code = code;
            this.Description = description;
            this.Date = date;
            this.Conflict = conflict;
            this.DeveloperId = developerId;
        }
        public void Update(
            string code,
            string description,
            DateTime date,
            bool conflict
        )
        {
            this.Code = code;
            this.Description = description;
            this.Date = date;
            this.Conflict = conflict;
        }
    }
}