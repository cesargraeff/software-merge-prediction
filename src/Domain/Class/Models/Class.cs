using Domain.Shared.Entities;

namespace Domain.Class.Models
{
    public class Class : Entity
    {
        public string Name { get; private set; }
        public int StartLine { get; private set; }
        public int FinishLine { get; private set; }

        public Class(
            string name,
            int startLine,
            int finishLine
        )
        {
            this.Name = name;
            this.StartLine = startLine;
            this.FinishLine = finishLine;
        }
        public void Update(
            string name,
            int startLine,
            int finishLine
        )
        {
            this.Name = name;
            this.StartLine = startLine;
            this.FinishLine = finishLine;
        }
    }
}