using MediatR;

using Domain.Shared.Commands;

namespace Domain.Branch.Commands
{
    public class DeleteBranchCommand : Command<Unit>
    {
        public Guid Id { get; set; }
    }
}