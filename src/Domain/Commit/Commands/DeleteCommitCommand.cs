using MediatR;

using Domain.Shared.Commands;

namespace Domain.Commit.Commands
{
    public class DeleteCommitCommand : Command<Unit>
    {
        public Guid Id { get; set; }
    }
}