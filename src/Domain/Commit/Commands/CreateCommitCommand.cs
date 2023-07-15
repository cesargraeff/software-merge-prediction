using MediatR;

using Domain.Shared.Commands;

namespace Domain.Commit.Commands
{
    public class CreateCommitCommand : Command<Unit>
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public bool Conflict { get; set; }
    }
}