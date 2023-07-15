using Domain.Shared.Entities;

namespace Domain.FileLine.Models
{
    public class FileLine : Entity
    {
        public int Line { get; private set; }
        public string Code { get; private set; }
        public int Operation { get; private set; }

        public FileLine(
            int line,
            string code,
            int operation
        )
        {
            this.Line = line;
            this.Code = code;
            this.Operation = operation;
        }
        public void Update(
            int line,
            string code,
            int operation
        )
        {
            this.Line = line;
            this.Code = code;
            this.Operation = operation;
        }
    }
}