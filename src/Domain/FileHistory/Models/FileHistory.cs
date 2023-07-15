using Domain.Shared.Entities;

namespace Domain.FileHistory.Models
{
    public class FileHistory : Entity
    {
        public int LinesAdded { get; private set; }
        public int LinesRemoved { get; private set; }
        public int Operation { get; private set; }

        public FileHistory(
            int linesAdded,
            int linesRemoved,
            int operation
        )
        {
            this.LinesAdded = linesAdded;
            this.LinesRemoved = linesRemoved;
            this.Operation = operation;
        }
        public void Update(
            int linesAdded,
            int linesRemoved,
            int operation
        )
        {
            this.LinesAdded = linesAdded;
            this.LinesRemoved = linesRemoved;
            this.Operation = operation;
        }
    }
}